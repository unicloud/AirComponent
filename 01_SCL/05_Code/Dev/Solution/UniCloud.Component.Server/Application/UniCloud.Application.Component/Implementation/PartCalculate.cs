using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Repositories.EntityFramework;
using UniCloud.Query.Component;

namespace UniCloud.Application.Implementation
{
    public class PartCalculate
    {
	 	
        #region 根据最新项目号，进行适用性检索

	 	/*
	 	//根据最新项目号，进行适用性检索			
		//对不在适用性内、还没有完成的、没有加入到工作包的到期任务进行删除.			
		//对在适用性内的飞机、部件进行遍历，生成或者更新到期任务。			
		public void calculateTaskMature(String taskno,Long taskid) throws AppException {
			
			Session sess = getHibernateTemplate().getSessionFactory().getCurrentSession();
			
			if(isNull(taskno) && isNull(taskid)){
				throw new AppException("请指定需要更新到期任务的维修项目号");
			}
			if(isNull(taskid)){
				Task task = findRealseTask(taskno);
				taskid = task.getTaskid();
			}
			if(isNull(taskno)){
				Task task = (Task)get(Task.class, taskid);
				taskid = task.getTaskid();
			}
			
			List app_new;
			//对不在适用性内、还没有完成的、没有加入到工作包的到期任务进行删除.
			List acapps = deleteHistoryTaskMature(taskno, taskid, sess);
			// 部件类：维修任务、EO  //飞机类：维修任务、EO
			if(isEmpty(acapps)){
				
				//适用性范围变化后界定后，进行增删改到期任务
				String sql = "select partid from TaskPnApps t where deleted=0 and taskid=";
				
				//根据最新项目号，进行适用性检索
				app_new = sess.createQuery(sql+taskid).list();
				
				//对在适用性内的飞机、部件进行遍历，生成或者更新到期任务。
				for (Iterator iter = app_new.iterator(); iter.hasNext();) {
					Long partid = (Long) iter.next();
					if(!isNull(partid)) {
						
						String pnsql = "from PartsCcRecordView t where t.isCurrent='Y' " +
								"and (t.ccType='装上' or instr(t.interval,'DA')>0 or instr(t.firstInt,'DA')>0) and t.partid=" +partid;
						//查找件号控制到了那些时控件
						List records = sess.createQuery(pnsql).list();
						//查找这个件号在该维修项目下由那几个间隔组(维修要求)控制
						List int_grps = new ArrayList();
						List grps = getPartsIntervals(partid, taskno, null, null);
						List grps_sig = new ArrayList();
						if(!isEmpty(grps)&&!isEmpty(records)){
							//去除间隔中重复组名
							for (Iterator iteratorgrps = grps.iterator(); iteratorgrps.hasNext();) {
								TaskInt grp = (TaskInt) iteratorgrps.next();
								String intGrp = grp.getIntGrp();
								if(!int_grps.contains(intGrp)){
									int_grps.add(intGrp);
									grps_sig.add(grp);
								}
							}
							//对每个控制到的件号、每个间隔组生成、更新一个到期任务
							for (Iterator iterator = records.iterator(); iterator.hasNext();) {
								PartsCcRecordView record = (PartsCcRecordView) iterator.next();
								for (Iterator ints = grps_sig.iterator(); ints.hasNext();) {
									TaskInt intGrp = (TaskInt) ints.next();
									TaskMature tma = new TaskMature();
									String grp = intGrp.getIntGrp();
									tma = getTaskMatureByTasknoAndGrp(taskno,grp,null,record.getPartserid());
									if(tma==null){
										tma = new TaskMature();
										tma.setIsAdd("N");
										tma.setIssys("Y");
										tma.setIsAccomplish("N");
									}
									tma.setTaskid(taskid);
									tma.setPartserid(record.getPartserid());
									tma.setIntGrp(grp);
									//计算到期日期 ---2010-09-01由于该方法运行事务太长，计算到期时间工作用其他接口实现
									List nextDates= calculateParts(record,taskno,intGrp);
									if(!isEmpty(nextDates)){
										tma.setAct(intGrp.getPolicyAct());
										intGrp = (TaskInt)nextDates.get(0);
										
										tma.setNextCy(intGrp.getNextCy());
										tma.setNextDate(intGrp.getNextDate());
										tma.setNextFh(intGrp.getNextFh());
										tma.setIsThres("N");
									}
									
									saveOrUpdate(tma);
								}
							}
						}
					}
				}
			} else { //机身类
				
				//适用性范围变化后界定后，进行增删改到期任务
				String sql = "select msn from TaskAcApps where deleted=0 and taskid=";

				//根据最新项目号，进行适用性检索
				app_new = sess.createQuery(sql+taskid).list();
				
				//对在适用性内的飞机、部件进行遍历，生成或者更新到期任务。
				for (Iterator iter = app_new.iterator(); iter.hasNext();) {
					
					String msn = (String) iter.next();
					AcUsageView ac = (AcUsageView) get(AcUsageView.class, msn);
					if(ac==null){
						continue;
					}
					//查找这个件号在该维修项目下由那几个间隔组(维修要求)控制
					List int_grps = new ArrayList();
					List grps = getMsnsIntervals(msn, taskno, null, null);
					List grps_sig = new ArrayList();
					if(!isEmpty(grps)){
						//去除间隔中重复组名
						for (Iterator iteratorgrps = grps.iterator(); iteratorgrps.hasNext();) {
							TaskInt grp = (TaskInt) iteratorgrps.next();
							if(grp!=null){
								
								String intGrp = grp.getIntGrp();
								if(!int_grps.contains(intGrp)){
									int_grps.add(intGrp);
									grps_sig.add(grp);
								}
							}
						}
						for (Iterator ints = grps_sig.iterator(); ints.hasNext();) {
							TaskInt intGrp = (TaskInt) ints.next();
							String grp = intGrp.getIntGrp();
							TaskMature tma = new TaskMature();
							//改造，增加当INT_GRP为NULL的也要查回来
							tma = getTaskMatureByTasknoAndGrp(taskno,grp,msn,null);
							if(tma==null){
								tma = new TaskMature();
							}
							tma.setTaskid(taskid);
							tma.setMsn(msn);
							tma.setIntGrp(grp);
							
							//计算到期日期 ---2010-09-01由于该方法运行事务太长，计算到期时间工作用其他接口实现
							List nextDates= calculateMsnTaskint(ac, taskno, intGrp);
							if(nextDates!=null){
								tma.setAct(intGrp.getPolicyAct());
								intGrp = (TaskInt)nextDates.get(0);
								tma.setNextCy(intGrp.getNextCy());
								tma.setNextDate(intGrp.getNextDate());
								tma.setNextFh(intGrp.getNextFh());
								if(intGrp.getNextDate()!=null){
									tma.setIsThres("Y");
								}
							}
							tma.setIsAdd("N");
							tma.setIssys("Y");
							tma.setIsAccomplish("N");
							save(tma);
						}
					}
				}
			}
		}
	    */

        #endregion

        #region 对不在适用性内、还没有完成的、没有加入到工作包的到期任务进行删除

		/*
		//对不在适用性内、还没有完成的、没有加入到工作包的到期任务进行删除.			
		private List deleteHistoryTaskMature(String taskno, Long taskid, Session sess) {
			
			//根据适用性判断是部件类的还是机身类的
			String acappsql = "select msn from TaskAcAppsView t where deleted=0 and taskid=" + taskid;
			List acapps = sess.createQuery(acappsql).list();
			if(isEmpty(acapps)){
				//适用于部件
				//对该项目机身的到期任务进行删除
				String delacsql = "delete from ruijian.task_mature m where m.is_add ='N' and m.is_accomplish ='N'" +
				" and m.taskid in (select t.taskid from ruijian.task t where t.taskno ='" + taskno +"')"+
				" and m.msn is not null";		
				int l = sess.createSQLQuery(delacsql).executeUpdate();
				if(l>0){
					log.info("删除:"+taskno + l+" 条机身到期任务记录");
				}					
				//对该项目部件不在该部件适用性范围的到期任务进行删除
				String delpnsql = "delete from ruijian.task_mature m where m.is_add ='N' and m.is_accomplish ='N'" +
				" and m.taskid in (select t.taskid from ruijian.task t where t.taskno ='" + taskno +"')"+
				" and (select s.partid from ruijian.snrreg s where m.partserid = s.partserid)" +
				" not in (select tp.partid from ruijian.Task_Pn_Apps tp where deleted=0 and tp.taskid="+taskid+")";
				int j = sess.createSQLQuery(delpnsql).executeUpdate();
				if(j>0){
					log.info("删除:"+taskno + j+" 条部件到期任务记录");
				}
			}else{
				//适用于机身
				//对该项目部件的到期任务进行删除
				String delpnsql = "delete from ruijian.task_mature m where m.is_add ='N' and m.is_accomplish ='N'" +
				" and m.taskid in (select t.taskid from ruijian.task t where t.taskno ='" + taskno +"')"+
				" and m.partserid is not null";
				
				int j = sess.createSQLQuery(delpnsql).executeUpdate();
				if(j>0){
					log.info("删除:"+taskno + j+" 条部件到期任务记录");
				}				
				//对该项目机身不在该机身适用性范围的到期任务进行删除
				String delacsql = "delete from ruijian.task_mature m where m.is_add ='N' and m.is_accomplish ='N'" +
				" and m.taskid in (select t.taskid from ruijian.task t where t.taskno ='" + taskno +"')"+
				" and m.msn not in (select tp.msn from ruijian.Task_ac_Apps tp where deleted=0 and tp.taskid="+taskid+")";		
				int l = sess.createSQLQuery(delacsql).executeUpdate();
				if(l>0){
					log.info("删除:"+taskno + j+" 条机身到期任务记录");
				}	
			}
			return acapps;
		}
		*/	

        #endregion

        #region 查找 部件 附件项 时限组 飞机 维修代码下的监控记录

        /*
		private TaskMature getTaskMatureByTasknoAndGrp(String taskno,String intGrp,String msn,Long partserid){
			
			Session sess = getHibernateTemplate().getSessionFactory().getCurrentSession();
			TaskMature ma = null;
			
			//select * from ruijian.Task_Mature m where m.taskid in 
			//(select t.taskid from ruijian.Task t where t.taskno='SFA-TEST1-6A')
			//and m.is_Add='N' and m.is_Accomplish ='N' and m.int_Grp='DEF' and m.msn = '24401';
			 
			String sql = "";
			sql = "from TaskMature m where m.isAdd='N' and m.isAccomplish ='N'" +
					"and m.taskid in (select t.taskid from Task t where t.taskno='" + taskno +"')";
			
			if(!isNull(intGrp)){
				sql = sql+ " and (m.intGrp='"+intGrp +"' or m.intGrp is null)";
			}
			if(!isNull(msn)){
				sql = sql + " and m.msn='" + msn+"'";
			}		
			if(!isNull(partserid)){
				sql = sql + " and m.partserid=" + partserid;
			}
			List lst = sess.createQuery(sql).list();
			
			if(!isEmpty(lst)){
				ma = (TaskMature)lst.get(0);
			}
			return ma;
		}
        */

		#endregion

        #region 批量处理更新到期监控的下次到期日期

	    /*代码参照
	     * <b>[功能简述]</b>
	     * <p>
	     * 更新到期监控的下次到期日期
	     * </p>
	     * <b>[功能详细描述]</b>
	     * <p>
	     * 根据传入的一组ID，查找出个个工卡下次的到期记录，重新计算它的下次到期时间
	     * </p>
	     * 
	     * @param TaskMature 工卡到期日期的主键ids
	     * @param update 对于用户手工填写的日期 如果传入了true则会用系统计算的时间来覆盖掉用户的，如果传入了FALSE则仍然使用用户的
	     * @return ture 计算成功 false 计算失败，没有任何适用的间隔
	     * @throws AppException
	     
	    public void calculateNextDate(String taskno,String msn,Long partid,Long partserid) throws AppException {
		
		    long begin = System.currentTimeMillis();
		    //根据参入的参数，进行到期任务查找
		    List matures = findTaskMatures(taskno,msn,partid,partserid);
		    if(!isEmpty(matures)) {
			    log.info("开始计算系统["+matures.size()+"]到期任务监控数据");
			    for (Iterator iter = matures.iterator(); iter.hasNext();) {
				    TaskMatureView mature = (TaskMatureView) iter.next();
				    calculateNextDate(mature);
			    }
		    }
		    long cost = (System.currentTimeMillis()-begin)/1000;
		    log.info("完成计算系统["+matures.size()+"] 到期任务监控数据，耗费时间:"+ String.valueOf(cost)+"秒");
	    }
        */

	    #endregion

        #region 通过特定条件查找到期监控记录

        /* 代码参照
	    private List findTaskMatures(String taskno,String msn,Long partid,Long partserid) throws AppException {
		    Session sess = getHibernateTemplate().getSessionFactory().getCurrentSession();
		
		    List lst = null;
		
		    //select * from  ruijian.Task_Mature_View t 
		    //where t.is_accomplish <> 'Y' and t.next_DATE is not null;
		    String sql = "";
		    sql = "from TaskMatureView t where t.isAccomplish<>'Y' and t.issys='是'";
		    if(taskno!=null && !"".equals(taskno)&&!"null".equals(taskno)){
			    sql = sql + " and t.taskno='" + taskno +"'";
		    }
            //sql = sql + " and t.taskno='TEST-FH'";//TODO
		
		    if(msn!=null && !"".equals(msn)&&!"null".equals(msn)){
			    sql = sql + " and t.msn='" + msn +"'";
		    }	
		    if(partid!=null && !"".equals(partid)&&partid.longValue()>0){
			    sql = sql + " and (t.partid=" + partid + " or t.nhpartid="+partid+")";
		    }				
		    if(partserid!=null && !"".equals(partserid)&&partserid.longValue()>0){
			    sql = sql + " and (t.partserid=" + partserid + " or t.nhPartserid="+partserid+")";
		    }		
		    lst = sess.createQuery(sql).list();
		
		    return lst;
	    }	
        */

        #endregion

        #region 单个处理更新到期监控的下次到期日期

	    /*代码参照
	     * <b>[功能简述]</b>
	     * <p>
	     * 更新到期工卡的下次到期日期
	     * </p>
	     * <b>[功能详细描述]</b>
	     * <p>
	     * 根据传入的一组ID，查找出个个工卡下次的到期记录，重新计算它的下次到期时间
	     * </p>
	     * 
	     * @param TaskMature 工卡到期日期的主键ids
	     * @param update 对于用户手工填写的日期 如果传入了true则会用系统计算的时间来覆盖掉用户的，如果传入了FALSE则仍然使用用户的
	     * @return ture 计算成功 false 计算失败，没有任何适用的间隔
	     * @throws AppException
	     
	    public boolean calculateNextDate(TaskMatureView t) throws AppException {
		
		    if(t == null){
			    return false;
		    }
		
		    String msn = t.getMsn();
		    String taskno = t.getTaskno();
		    List intlst = null;
		    TaskInt intGrp = new TaskInt();
		    if(t.getIntGrp()!=null && !"".equals(t.getIntGrp())){
			    String[] fieldName = new String[]{"taskid","intGrp"};
			    Object[] fieldValue = new Object[]{t.getTaskid(),t.getIntGrp()};
			    List grps = findByField(TaskInt.class, fieldName, fieldValue);
			    intGrp = (TaskInt)grps.get(0);
		    }
		
		    //对到期任务分机身、部件两种处理方式
		    if(msn == null){
			
			    Long partserid = t.getPartserid();
			    PartsCcRecordView record = getPartCcHistory(null,partserid);
			    //没有相关部件记录
			    if(!isNull(record)){
				    intlst = calculateParts(record,taskno,intGrp);
			    }
		    }else{
			    // 获取飞机日用率
			    AcUsageView ac = (AcUsageView) get(AcUsageView.class, msn);
			    // 获取飞机适用的间隔组
			    String int_grp = t.getIntGrp();
			    if(!isNull(ac)){
				    intlst = calculateMsnTaskint(ac,taskno,intGrp);
			    }
		    }
		    TaskMature tm = new TaskMature();
		    BeanUtils.copyProperties(tm, t);
		    for (Iterator iter = intlst.iterator(); iter.hasNext();) {
			    TaskInt it = (TaskInt) iter.next();
			    tm.setNextDate(it.getNextDate());
			    tm.setNextCy(it.getNextCy());
			    tm.setNextFh(it.getNextFh());
			    tm.setIssys("Y");
			    tm.setIntGrp(it.getIntGrp());
			    update(tm);
		    }
		    return true;
	    }	
	    */

        #endregion

        #region 根据参数判断查找需要最新的部件的履历

        /*代码参照 
	    private PartsCcRecordView getPartCcHistory(String taskno,Long partserid)throws AppException{
		    Session sess = getHibernateTemplate().getSessionFactory().getCurrentSession();
		    PartsCcRecordView record = null;
		    //查找最新的拆换履历，并且只找装上的和日历日控制的.
			//select t.partserid 
			//from ruijian.parts_cc_record_view t 
			//where t.is_current ='Y' and (t.cc_type = '装上' or instr('DA',t.interval)>0 or instr('DA',t.first_int)>0);

		    String sql = "";
		    sql = "from PartsCcRecordView t where t.isCurrent='Y' and (t.ccType='装上' or instr(t.interval,'DA')>0 or instr(t.firstInt,'DA')>0) ";
		    if(taskno!=null && !"".equals(taskno)&&!"null".equals(taskno)){
			    sql = sql + "and t.itemNo='" + taskno +"'";
		    }
		
		    //sql = sql + "and t.itemNo='PN-A-CA'";
		    if(partserid!=null && !"".equals(partserid)&&partserid.longValue()>0){
			    sql = sql + "and t.partserid=" + partserid;
		    }		
		    List records = sess.createQuery(sql).list();
		    if(!isEmpty(records)){
			    record = (PartsCcRecordView)records.get(0);
		    }
		    return record;
	    }	
       */

        #endregion

        #region 计算部件到期任务时间

        /*代码参照
	    private List calculateParts(PartsCcRecordView record,String taskno,TaskInt int_grp)throws AppException{
		
		    //根据部件的 类型、上级件类型、维护项目号、控制方式判断出合适的连续CY系数
		    String spc = record.getSpc();
		    String nhspc = record.getNhSpc();
		    String itemno = record.getItemNo();
		    String controlmode = record.getControlMode();
		
		    long tourchgoCyRate = PartHardCodeConstant.PARTS_TOUCHGO_CALCULATE_RATE_NORMAL;//2
		    //发动机下级部件LLP控制
		    if("EG".equals(spc)){
			    tourchgoCyRate = PartHardCodeConstant.PARTS_TOUCHGO_CALCULATE_RATE_ENG_AXIS;//5
		    }		
		    if("EG".equals(nhspc)&& "LLP".equals(controlmode)){
			    tourchgoCyRate = PartHardCodeConstant.PARTS_TOUCHGO_CALCULATE_RATE_ENG_LLP;//5
		    }
		    //特别维护发动机轴的维修方案SF72-06、SF72-09、SF72-19 
		    if("EG".equals(nhspc)&&("SF72-06".equals(itemno) || "SF72-09".equals(itemno) || "SF72-19".equals(itemno))){
			    tourchgoCyRate = PartHardCodeConstant.PARTS_TOUCHGO_CALCULATE_RATE_ENG_AXIS;//1
		    }
		    //起落架以及下级件 1
		    if("LG".equals(nhspc) || "LG".equals(spc)){
			    tourchgoCyRate = PartHardCodeConstant.PARTS_TOUCHGO_CALCULATE_RATE_LP;//1
		    }

		    //APU 0
		    if("AP".equals(nhspc) || "AP".equals(spc)){
			    tourchgoCyRate = 10000000;//APU不增加连续循环操作
		    }
		    //获取该序号件当前最新的飞行数据
		    Map out = getSnFlyData(record.getPartserid(),record, new Date());
		    List intlst = calculatePartTaskint(record,taskno,tourchgoCyRate,int_grp,out);
		    return intlst;	
	    }
        */

        #endregion

        #region 计算机身到期任务时间

	    /* 代码参照
	     * 计算机身到期任务时间	     
	    private List calculateMsnTaskint(AcUsageView ac,String taskno,TaskInt intGrp)throws AppException{
		
		    Session sess = getHibernateTemplate().getSessionFactory().getCurrentSession();
		    List intList = new ArrayList();
		    long tourchgoCyRate = PartHardCodeConstant.PARTS_TOUCHGO_CALCULATE_RATE_NORMAL;//2
		    double tsnfh = 0;//用来保存当前部件，飞机的FH
		    long tsncy = 0;//用来保存当前部件，飞机的CY,CA
		    long tsnca = 0;
		    long tsntagcy = 0;//引进后连续循环
		    long tsdtagcy = 0;//引进前连续循环
		    String msn = ac.getMsn();
		
		    // 获取飞机适用的间隔组
		    tsnfh = ac.getTsnFh() == null ? 0d : ac.getTsnFh().doubleValue();
		    tsncy = ac.getTsnCy() == null ? 0L : ac.getTsnCy().longValue();
		    tsnca = ac.getTsnDa() == null ? 0L : ac.getTsnDa().longValue();		
		    tsntagcy = ac.getTsnTagcy() == null ? 0L : ac.getTsnTagcy().longValue();
		    tsdtagcy = ac.getTsdTagcy() == null ? 0L : ac.getTsdTagcy().longValue();				
		
		    double acRateFh = 10;
		    double acRateCy = 4;
		    double acRateCa = 1;
		    acRateFh = ac.getUsageFh()==null?10:ac.getUsageFh();
		    acRateCy = ac.getUsageFh()==null?4:ac.getUsageCy();
		    String int_grp=null;
		
		    if(intGrp==null){
			    int_grp = "DEF";
		    }else{
			    int_grp = intGrp.getIntGrp();
		    }
		
		    TaskMature tm = findLastMature(taskno, sess, msn, int_grp);
		
		    //遍历，找到最小的fh及其对应的TaskInt(存在多个最小的情况)
		    //当是公用间隔时不需要串参数
		    if("DEF".equals(int_grp)){
			    int_grp = null;
		    }
		    List lst = getMsnsIntervals(msn, taskno, int_grp, null);
		
		    if(!isEmpty(lst)){
			    for (Iterator iter = lst.iterator(); iter.hasNext();) {
				    TaskInt ti = (TaskInt) iter.next();
				    if(!isNull(ti)){
					
					    //根据激活策略找出要计算的fh、cy、ca数据
					    Double msnFh = tsnfh;
					    Long msnCy = tsncy;
					    Long msnCa = tsnca;
					
					    //连续起落的处理 --顺丰机务系统-用户反馈_201008241_RE.doc 引进前的按正常计算，引进后的按0.5计算
					    //msnCy = new Long(msnCy.longValue() + (tsntagcy-tsdtagcy)/tourchgoCyRate);
					
					    ti = calculateTaskint(ti, tm, msnFh, msnCy,tsntagcy,msnCa, acRateFh, acRateCy, acRateCa,tourchgoCyRate,null);
					    if(ti!=null){
						    intList.add(ti);
					    }
				    }
			    }
		    }
		    return intList;		
	    }
        */

        #endregion

        #region 计算到期监控 时限到期情况

        /* 代码参照
	    private TaskInt calculateTaskint(TaskInt ti,TaskMature tm,Double tsn,Long csn,Long csn_ta,Long csnCa,Double acRateFh,Double acRateCy,Double acRateCa,long tourchgoCyRate,String compareType)
		    throws AppException{
		
		    Calendar calendar = Calendar.getInstance();
		    //比较TaskInt中是否有合适目前飞行数据的间隔
		    ti = compareTaskInt(ti, tsn, csn, csnCa, compareType);
		    boolean inFh = "Y".equals(ti.getInFh()) ? true : false;
		    boolean inCy = "Y".equals(ti.getInCy()) ? true : false;
		    boolean inCa = "Y".equals(ti.getInCa()) ? true : false;
		    if(!inFh && !inCy && !inCa){
			    log.info("维修项目编号:"+ti.getTaskid()+"间隔组:"+ti.getIntGrp()+" 未激活");
			    return ti;
		    }
		    //已经使用的时间
		    long usedFh = 0;
		    long usedCy = 0;
		    long usedCa = 0;
		    //到期的时间
		    double nextFh = 0;
		    long nextCy = 0;
		    Date nextDate = null;
		
		    //剩余的时间
		    long remFh = 99999999;
		    long remCy = 99999999;
		    long remCa = 99999999;
		
		    long remCyToCa = 99999999;
		    long remFhToCa = 99999999;
		    if(tm != null) {
			    //如果有上次的执行记录，则 剩余FH = 间隔FH - (序号件现在的FH-上次执行时的FH)
			    if(inFh) {
				    if("TSN".equals(ti.getPolicyAct())) {
					    //USED_TIME = 序号件现在的FH-上次执行时的FH
					    long ccomplishFh = tm.getAccomplishFh()==null?0:tm.getAccomplishFh().longValue();
					    usedFh = tsn.longValue() - ccomplishFh;
					    nextFh = ccomplishFh;
				    }else if("TSR".equals(ti.getPolicyAct())) {
					    long ccomplishTsr = tm.getAccomplishTsr()==null?0:tm.getAccomplishTsr().longValue();
					    usedFh = tsn.longValue() - ccomplishTsr;
					    nextFh = ccomplishTsr;
				    }if("TSO".equals(ti.getPolicyAct())) {
					    long ccomplishTso = tm.getAccomplishTso()==null?0:tm.getAccomplishTso().longValue();
					    usedFh = tsn.longValue() - ccomplishTso;
					    nextFh = ccomplishTso;
				    }
				    //剩余FH = 间隔FH - (序号件现在的FH-上次执行时的FH)
				    remFh = ti.getIntFh().longValue() - usedFh;
				    nextFh= nextFh+ ti.getIntFh();
				    remFhToCa = new Double(remFh * (acRateCa/acRateFh )).longValue();
			    }
			
			    if(inCy) {
				    if("TSN".equals(ti.getPolicyAct())) {
					    long ccomplishCy = tm.getAccomplishCy()==null?0:tm.getAccomplishCy().longValue();
					    long ccomplishCyt = tm.getAccomplishCyt()==null?0:tm.getAccomplishCyt().longValue();
					    usedCy = csn - ccomplishCy;
					    usedCy = usedCy + (csn_ta - ccomplishCyt)/tourchgoCyRate;
					    nextCy = ccomplishCy+ccomplishCyt/tourchgoCyRate;
				    }
				    else if("TSR".equals(ti.getPolicyAct())) {
					    long ccomplishCsr = tm.getAccomplishCsr()==null?0:tm.getAccomplishCsr().longValue();
					    long ccomplishCyt = tm.getAccomplishCyt()==null?0:tm.getAccomplishCyt().longValue();
					    usedCy = csn - ccomplishCsr;
					    usedCy = csn + (csn_ta - ccomplishCyt)/tourchgoCyRate;
					    nextCy = ccomplishCsr+ccomplishCyt/tourchgoCyRate;
				    }
				    if("TSO".equals(ti.getPolicyAct())) {
					    long ccomplishCso = tm.getAccomplishCso()==null?0:tm.getAccomplishCso().longValue();
					    long ccomplishCyt = tm.getAccomplishCyt()==null?0:tm.getAccomplishCyt().longValue();					
					    usedCy = csn - ccomplishCso;
					    usedCy = csn + (csn_ta - ccomplishCyt)/tourchgoCyRate;
					    nextCy = ccomplishCso+ccomplishCyt/tourchgoCyRate;
				    }
				    remCy = ti.getIntCy().longValue() - usedCy;
				    nextCy= nextCy+ ti.getIntCy();
				
				    //将CY、FH统一换算成CA，方便比较大小
				    remCyToCa = new Double(remCy * (acRateCa / acRateCy)).longValue();
			    }
			    if(inCa) {
				    usedCa = daysBetween(tm.getAccomplishDate(), new Date()); 
				    remCa = ti.getIntDays().longValue() - usedCa;
			    }
		    }else {
			    if(inFh) {
				    //如果没有上次的执行记录，则该序号件需要做首检，则 剩余FH = 首检FH - 序号件现在的FH
				    if(ti.getThresFh()==null || ti.getThresFh().longValue()<=0){
					    ti.setThresFh(ti.getIntFh());
				    }
				    usedFh = tsn.longValue();
				    remFh = ti.getThresFh().longValue() - usedFh;
				    nextFh= ti.getThresFh();
				    remFhToCa = new Double(remFh * (acRateCa/acRateFh )).longValue();
			    }
			    if(inCy) {
				    usedCy = csn.longValue();
				    usedCy = csn + csn_ta/tourchgoCyRate;		
				    if(ti.getThresCy()==null || ti.getThresCy().longValue()<=0){
					    ti.setThresCy(ti.getIntCy());
				    }						
				    remCy = ti.getThresCy().longValue() - usedCy;
				    nextCy = ti.getThresCy();
				
				    //将CY、CA统一换算成FH，方便比较大小
				    remCyToCa = new Double(remCy * (acRateCa / acRateCy)).longValue();
			    }
			    if(inCa) {
				    usedCa = csnCa.longValue();
				    if(ti.getThresDay()==null || ti.getThresDay().longValue()<=0){
					    ti.setThresDay(ti.getIntDays());
				    }
				    remCa = ti.getThresDate() != null ? daysBetween(new Date(), ti.getThresDate()) : (ti.getThresDay().longValue() - csnCa.longValue());
			    }
		    }
		
		    //计算最小的fh
		    long nextday = 0;
		
		    //计算维修要求、控制方式、剩余时间等
		    //计算到期日期 比较三个到期日期的大小，根据先到，后到。选择适用的日期
		    if ("X".equals(ti.getPolicyExec())) {
			    nextday = NumberUtils.minimum(remCa, remCyToCa, remFhToCa);
		    }
		    // 后到为准
		    else {
			    if(remCyToCa != 0 && remCyToCa != 99999999){remCyToCa = 0;}
			    if(remFhToCa != 0 && remFhToCa != 99999999){remFhToCa = 0;}
			    nextday = NumberUtils.maximum(remFh, remCyToCa, remFhToCa);
		    }
    //		if(tm!=null && tm.getAccomplishDate()!=null){
    //			calendar.setTime(tm.getAccomplishDate());
    //		}else{
			    calendar = Calendar.getInstance();
    //		}
		    int day = new Long(nextday).intValue();
		
		    calendar.add(Calendar.DATE,day);
		    nextDate = calendar.getTime();
		
    //		Date today = new Date();
    //		if(nextDate == today){
    //			calendar = Calendar.getInstance();
    //			calendar.add(Calendar.DATE, 1);
    //			nextDate = calendar.getTime();
    //		}
		    ti.setNextDate(nextDate);
		    ti.setNextCy(nextCy);
		    ti.setNextFh(nextFh);
		
		    //控制方式
		
		    //剩余时间、使用时间:XXXXFH,XXXXCY,XXXXCA
		    String remainTime = "";	
		    if(remFh != 0 && remFh != 99999999){
			    remainTime = remainTime + remFh+"FH,";
		    }
		    if(remCy != 0 && remCy != 99999999){
			    remainTime = remainTime + remCy+"CY,";
		    }
		    if(remCa != 0 && remCa != 99999999){
			    remainTime = remainTime + remCa+"CA";
		    }
		    ti.setRemainTime(String.valueOf(remainTime));
		
		    String usedTime = "";
		    if(usedFh != 0 && usedFh != 99999999){
			    usedTime = usedTime + usedFh+"FH,";
		    }
		    if(usedCy != 0 && usedCy != 99999999){
			    usedTime = usedTime + usedCy+"CY,";
		    }
		    if(usedCa != 0 && usedCa != 99999999){
			    usedTime = usedTime + usedCa+"CA";
		    }					
		    ti.setUsedTime(usedTime);
		
		    //剩余FH、CY:同上
		    Long remainFh = null;
		    if(remFh != 0 && remFh!=99999999){
			    remainFh = remFh;
			    ti.setRemainFh(new Double(remainFh));
		    }else{
		    }
		    Long remainCy = null;
		    if(remCy != 0 && remCy!=99999999){
			    remainCy = remCy;
			    ti.setRemainCy(remainCy);
		    }
		    if(remCa != 0 && remCa != 99999999){
			    ti.setRemainCa(remCa);
		    }
		    return ti;
	    }
        */

        #endregion

        #region 查找到期时限上一次完成记录

        /* 代码参照
	    private TaskMature findLastMature(String taskno, Session sess, String msn, String int_grp) {
		    TaskMature tm = null;
		    String sql = "select t.id from ruijian.task_mature t " +
				    " where t.taskid in (select i.taskid from ruijian.task i where i.taskno = '"+taskno+"')" +
				    " and t.msn = " + msn + " and t.is_accomplish = 'Y'" + 
				    " and t.int_grp='"+int_grp+ "'" +
				    " order by t.accomplish_date desc";
		    List tms = sess.createSQLQuery(sql).list();
		    if(!isEmpty(tms)) {
			    BigDecimal b = (BigDecimal)tms.get(0);
			    tm = (TaskMature)get(TaskMature.class, new Long(b.longValue()));
		    }
		    return tm;
	    }
        */

        #endregion
         
        #region 计算部件的附件项中适用的维修项目间隔

	    /* 代码参照
	     * 计算该序号件的维修方案中适用的维修项目间隔
	     * @param record PartsCcRecord
	     * @param inputs<ui>:
	     * <ul>tsn -- 自出厂空中时间FH(Double)</ul>
	     * <ul>csn -- 自出厂空中时间CY(Long)</ul>
	     * <ul>tsnCa -- 自出厂飞行天数DA(Long)</ul>
	     * <ul>tsr -- 自上次修理的空中时间FH(Double)</ul>
	     * <ul>csr -- 自上次修理的空中时间CY(Long)</ul>
	     * <ul>tsrCa -- 自上次修理的DA(Long)</ul>
	     * <ul>tso -- 自上次大修的空中时间FH(Double)</ul>
	     * <ul>cso -- 自上次大修的空中时间CY(Long)</ul>
	     * <ul>tsoCa -- 自上次大修的飞行天数DA(Long)</ul></ui>
	     * @return Map<ui>:
	     * <ul>taskInt -- TaskInt</ul>
	     * <ul>maintainence -- (String)</ul>
	     * <ul>control -- (String)</ul>
	     * <ul>usedTime -- (Long)</ul>
	     * <ul>remainTime -- (String)</ul>
	     * <ul>remainFh -- (Double)</ul>
	     * <ul>remainCy -- (Long)</ul></ui>
	     * @throws AppException

	    private List calculatePartTaskint(PartsCcRecordView record,String taskno,long tourchgoCyRate,TaskInt ti,Map inputs) throws AppException {
		
		    Session sess = getHibernateTemplate().getSessionFactory().getCurrentSession();
		    List intList = new ArrayList();
		    TaskMature tm = null;
		
		    double acRateFh = 10;
		    double acRateCy = 4;
		    double acRateCa = 1;
		    String compareType = null;
		    Long csnRepeatcy = (Long)inputs.get("csnRepeatcy");
		    //如果上次记录为"装上"，则在计算时要考虑TaskInt中定义的FH、CY、CA
		    if("装上".equals(record.getCcType())) {
			    //获取飞机的日利用率
			    List mus = findByField(Msnintunit.class, "msn", record.getMsn()) ;
			    if(!isEmpty(mus)) {
				    for(Iterator it = mus.iterator(); it.hasNext(); ) {
					    Msnintunit mu = (Msnintunit)it.next();
					    if("FH".equals(mu.getUnit())) {
						    acRateFh = mu.getWeeklyprod().doubleValue();
					    }
					    else if("CY".equals(mu.getUnit())) {
						    acRateCy = mu.getWeeklyprod().doubleValue();
					    }
					    else if("CA".equals(mu.getUnit())) {
						    acRateCa = mu.getWeeklyprod().doubleValue();
					    }
				    }
			    }
			    else {
				    throw new AppException("抱歉，您要计算的部件所在飞机并未设置日利用率，请先设置后再计算!");
			    }
		
			    //获取该序号件最近一次执行该维修项目的记录情况TaskMature
			    String sql = "select t.id from ruijian.task_mature t " +
					    " where t.taskid in (select i.taskid from ruijian.task i where i.taskno = '"+taskno+"')" +
					    " and t.partserid = " + record.getPartserid() + " and t.is_accomplish = 'Y'" +
					    " order by t.accomplish_date desc";
			    List tms = sess.createSQLQuery(sql).list();
			    if(!isEmpty(tms)) {
				    BigDecimal b = (BigDecimal)tms.get(0);
				    tm = (TaskMature)get(TaskMature.class, new Long(b.longValue()));
			    }
		    }else {
			    //如果上次记录不是"装上"，则计算时就只需考虑TaskInt中定义的CA 
			    compareType = "CA";
		    }
		
		    //遍历，找到最小的fh及其对应的TaskInt(存在多个最小的情况)
		    //当是公用间隔时不需要串参数
				
		    //根据激活策略找出要计算的fh、cy、ca数据
		    Double snFh = null;
		    Long snCy = null;
		    Long snCa = null;
		    if("TSN".equals(ti.getPolicyAct())) {
			    snFh = (Double)inputs.get("tsn");
			    snCy = (Long)inputs.get("csn");
			    snCa = (Long)inputs.get("tsnCa");
		    }
		    else if("TSR".equals(ti.getPolicyAct())) {
			    snFh = (Double)inputs.get("tsr");
			    snCy = (Long)inputs.get("csr");
			    snCa = (Long)inputs.get("tsrCa");
		    }
		    if("TSO".equals(ti.getPolicyAct())) {
			    snFh = (Double)inputs.get("tso");
			    snCy = (Long)inputs.get("cso");
			    snCa = (Long)inputs.get("tsoCa");
		    }
		
		    calculateTaskint(ti, tm, snFh, snCy,csnRepeatcy, snCa, acRateFh, acRateCy, acRateCa,tourchgoCyRate,compareType);
		
		    //控制方式
		    String[] fields = new String[]{"taskid", "intGrp"};
		    Object[] values = new Object[]{ti.getTaskid(), ti.getIntGrp()};
		    List tpas = findByField(TaskPnApps.class, fields, values);
		    if(!isEmpty(tpas)) {
			    TaskPnApps tpa = (TaskPnApps)tpas.get(0);
			    ti.setControl(tpa.getControlMode());
		    }
		    intList.add(ti);
		    return intList;
	    }
        */

        #endregion

        #region 计算部件的附件项中的维修项目间隔是否适用

        /* 代码参照
	        * 
	        * @param ti TaskInt
	        * @param snFh
	        * @param snCy
	        * @param snCa
	        * @param compareType: 需比较的间隔组标志，FH - 只比较FH不为空的间隔组，CY - CY不为空的间隔组，CA - CA不为空的间隔组，null - 所有间隔组
	        * @return
	        * @throws AppException
	        
        private TaskInt compareTaskInt(TaskInt ti, Double snFh, Long snCy, Long snCa, String compareType) throws AppException {
	        String inFh = "N";
	        String inCy = "N";
	        String inCa = "N";
	        if(compareType == null) {
			
		        if((ti.getIntDays() != null && ti.getIntDays().longValue() != 0) || (ti.getThresDay() != null && ti.getThresDay().longValue() != 0)
				        || ti.getThresDate() != null ) {
			        //判断目前的snCa是否则minCa与maxCa范围之内
			        long min = ti.getMinDays()==null?0:ti.getMinDays().longValue();
			        long max = ti.getMaxDays()==null || ti.getMaxDays().longValue() < 0 ? 99999999 : ti.getMaxDays().longValue(); //-1表示无穷大
			        inCa = snCa >= min && snCa <= max ? "Y" : "N";
		        }
		        if((ti.getIntFh() != null && ti.getIntFh().longValue() != 0)||(ti.getThresFh() != null && ti.getThresFh().longValue() != 0)) {
			        long min2 = ti.getMinFh()==null?0:ti.getMinFh().longValue();
			        long max2 = ti.getMaxFh()==null || ti.getMaxFh().longValue() < 0 ? 99999999 : ti.getMaxFh().longValue(); //-1表示无穷大
			        inFh = snFh >= min2 && snFh <= max2 ? "Y" : "N";
		        }
		        if((ti.getIntCy() != null && ti.getIntCy().longValue() != 0) || (ti.getThresCy() != null && ti.getThresCy().longValue() != 0)) {
			        long min3 = ti.getMinCy()==null?0:ti.getMinCy().longValue();
			        long max3 = ti.getMaxCy()==null || ti.getMaxCy().longValue() < 0 ? 99999999 : ti.getMaxCy().longValue(); //-1表示无穷大
			        inCy = snCy >= min3 && snCy <= max3 ? "Y" : "N";
		        }
	        }else if(compareType == "CA") {
		        if((ti.getIntDays() != null && ti.getIntDays().longValue() != 0) || (ti.getThresDay() != null && ti.getThresDay().longValue() != 0)
				        || ti.getThresDate() != null ) {
			        //判断目前的snCa是否则minCa与maxCa范围之内
			        long min = ti.getMinDays()==null?0:ti.getMinDays().longValue();
			        long max = ti.getMaxDays()==null || ti.getMaxDays().longValue() < 0 ? 99999999 : ti.getMaxDays().longValue(); //-1表示无穷大
			        inCa = snCa >= min && snCa <= max ? "Y" : "N";
		        }
	        }else if(compareType == "FH") {
		        if((ti.getIntFh() != null && ti.getIntFh().longValue() != 0)||(ti.getThresFh() != null && ti.getThresFh().longValue() != 0)) {
			        long min = ti.getMinFh()==null?0:ti.getMinFh().longValue();
			        long max = ti.getMaxFh()==null || ti.getMaxFh().longValue() < 0 ? 99999999 : ti.getMaxFh().longValue(); //-1表示无穷大
			        inFh = snFh >= min && snFh <= max ? "Y" : "N";
		        }
	        }else if(compareType == "CY") {
		        if((ti.getIntCy() != null && ti.getIntCy().longValue() != 0) || (ti.getThresCy() != null && ti.getThresCy().longValue() != 0)) {
			        long min = ti.getMinCy()==null?0:ti.getMinCy().longValue();
			        long max = ti.getMaxCy()==null || ti.getMaxCy().longValue() < 0 ? 99999999 : ti.getMaxCy().longValue(); //-1表示无穷大
			        inCy = snCy >= min && snCy <= max ? "Y" : "N";
		        }
	        }
	        ti.setInCa(inCa);
	        ti.setInFh(inFh);
	        ti.setInCy(inCy);
	        return ti;
        }	
        */

        #endregion

        #region 根据序号获取该序号件在指定日期的飞行数据

        /** 代码参照
	     * 根据序号获取该序号件在指定日期的飞行数据
	     * @param partserid
	     * @param somedate
	     * @return Map<ui>:
	     * <ul>record -- 最近一次的拆换履历数据,如果没有则返回null</ul>
	     * <ul>tsn -- 自出厂空中时间FH(Double)</ul>
	     * <ul>tsnEngine -- 自出厂空地时间FH(Double)</ul>
	     * <ul>csn -- 自出厂空中时间CY(Long)</ul>
	     * <ul>csnRepeatcy -- 自出连续起落CY(Long)</ul>
	     * <ul>tsnCa -- 自出厂飞行天数DA(Long)</ul>
	     * <ul>tsr -- 自上次修理的空中时间FH(Double)</ul>
	     * <ul>csr -- 自上次修理的空中时间CY(Long)</ul>
	     * <ul>tsrCa -- 自上次修理的DA(Long)</ul>
	     * <ul>tso -- 自上次大修的空中时间FH(Double)</ul>
	     * <ul>cso -- 自上次大修的空中时间CY(Long)</ul>
	     * <ul>tsoCa -- 自上次大修的飞行天数DA(Long)</ul></ui>
	     * @throws AppException
	     
	    private Map getSnFlyData(Long partserid,PartsCcRecordView r,Date somedate) throws AppException {
		    Map out = new HashMap();
		    PartsCcRecordView record = null;
		    Double tsn = new Double(0);
		    Double tsnEngine = new Double(0);
		    Long csn = new Long(0);
		    Long csnRepeatcy = new Long(0);
		    Long tsnCa = new Long(0);
		    Double tsr = new Double(0);
		    Long csr = new Long(0);
		    Long tsrCa = new Long(0);
		    Double tso = new Double(0);
		    Long cso = new Long(0);
		    Long tsoCa = new Long(0);
		    Long csi = new Long(0);
		    Double tsi = new Double(0);
		    Long csiRepeatcy = new Long(0);
		    //第1次，产生PART_CC_RECORD记录:TSN、CSN、TSR、CSR、TSO、CSO、TSN_CA、TSR_CA、TSO_CA为0
		    String[] fieldNames = new String[]{"partserid","isCurrent"};
		    Object[] fieldValues = new Object[]{partserid,"Y"};
		
		    if(r==null){
			    List lst = findByField(PartsCcRecordView.class, fieldNames, fieldValues,"ccDate",false);
			    if(!isEmpty(lst))
				    r = (PartsCcRecordView)lst.get(0);
		    }
		    if(r!=null) {
			    record = r;
			    tsn = r.getTsn()==null? 0:r.getTsn();
			    csn = r.getCsn()==null? 0:r.getCsn();
			    tsr = r.getTsr()==null? 0:r.getTsr();
			    csr = r.getCsr()==null? 0:r.getCsn();
			    tso = r.getTso()==null? 0:r.getTso();
			    cso = r.getCso()==null? 0:r.getCso();
			    tsnEngine = r.getTsnEngine()==null? 0:r.getTsnEngine();
			    csnRepeatcy = r.getCsnRepeat()==null? 0:r.getCsnRepeat();
			    tsnCa = r.getTsnCa()==null?0:r.getTsnCa();
			    tsrCa = r.getTsrCa()==null?0:r.getTsrCa();
			    tsoCa = r.getTsoCa()==null?0:r.getTsoCa();			
			    long d = daysBetween(r.getCcDate(), somedate);
			    if("拆下".equals(r.getCcType())) {
				    //非第1次，上次为“拆下”的情况
				    //A、TSN、CSN、TSR、CSR、TSO、CSO、TSN_ENGINE、CSN_REPEAT取上次对应的值
				    tsn = r.getTsn()==null? 0:r.getTsn();
				    csn = r.getCsn()==null? 0:r.getCsn();
				    tsr = r.getTsr()==null? 0:r.getTsr();
				    csr = r.getCsr()==null? 0:r.getCsn();
				    tso = r.getTso()==null? 0:r.getTso();
				    cso = r.getCso()==null? 0:r.getCso();
				    tsnEngine = r.getTsnEngine()==null? 0:r.getTsnEngine();
				    csnRepeatcy = r.getCsnRepeat()==null? 0:r.getCsnRepeat();
				    //B、TSN_CA、TSR_CA、TSO_CA为上次对应的值再加上（本次操作的日期跟上次操作的日期之间的天数）
				    tsnCa = new Long(tsnCa.longValue() + d);
				    tsrCa = new Long(tsrCa.longValue() + d);
				    tsoCa = new Long(tsoCa.longValue() + d);
			    }
			    else if("装上".equals(r.getCcType())) {
				
				    //非第1次，上次为“安装”的情况
				    Double fh = new Double(0);
				    Long cy = new Long(0);
				
				    Map acdata = getIAcService().getFlyData(r.getMsn(), r.getCcDate(), somedate);
				    Double cur_fh = (Double)acdata.get("fh");
				    Long cur_cy = (Long)acdata.get("cy");
				    Long apuHoursMm = ((Long)acdata.get("apuHoursMm"));
				    Long apuCy = ((Long)acdata.get("apuCy"));
				    Long touchgoCy = ((Long)acdata.get("touchgoCy")); 
				    if(touchgoCy==null){
					    touchgoCy = new Long(0); 
				    }
				    if("AP".equals(r.getSpc())||"AP".equals(r.getNhSpc())){
					    if(apuHoursMm==null){
						    apuHoursMm = new Long(0); 
					    }
					    if(apuCy==null){
						    apuCy = new Long(0); 
					    }					
					    Double apu_fh = AcServerUtil.parseLongToDouble(apuHoursMm.longValue());
					    double fhRate = getRate(record);
					    cy = apuCy;
					    fh = new Double(AcServerUtil.addHhmm(apu_fh,cur_fh.doubleValue()*fhRate));
					    csi = apuCy;
					    tsi = apu_fh;
				    }else{
					    fh = cur_fh;
					    cy = cur_cy;
					    csi = cy;
					    tsi = fh;
				    }
				
				    //A、TSN、TSR、TSO为上次对应再加上（本次操作的日期跟上次操作的日期之间的飞机飞行的FH）
				    tsn = new Double(AcServerUtil.addHhmm(tsn.doubleValue(), fh.doubleValue()));
				    tsr = new Double(AcServerUtil.addHhmm(tsr.doubleValue(), fh.doubleValue()));
				    tso = new Double(AcServerUtil.addHhmm(tso.doubleValue(), fh.doubleValue()));
				
			        //B、CSN、CSR、CSO为上次对应再加上（本次操作的日期跟上次操作的日期之间的飞机飞行的CY）
				    csn = new Long(csn.longValue() + cy.longValue());
				    csr = new Long(csr.longValue() + cy.longValue());
				    cso = new Long(cso.longValue() + cy.longValue());
				
			        //C、TSN_CA、TSR_CA、TSO_CA为上次对应的值再加上（本次操作的日期跟上次操作的日期之间的天数）
				    tsnCa = new Long(tsnCa.longValue() + d);
				    tsrCa = new Long(tsrCa.longValue() + d);
				    tsoCa = new Long(tsoCa.longValue() + d);
				
			        //D、TSN_ENGINE为上次的对应的值加上（本次操作的日期跟上次操作的日期之间的飞机飞行的空地FH）
				    tsnEngine = new Double(AcServerUtil.addHhmm(tsnEngine == null ? 0d : tsnEngine.doubleValue(), fh.doubleValue()));
				
			        //E、CSN_REPEAT为上次的对应的值加上（本次操作的日期跟上次操作的日期之间的飞机飞行的连续CY）
				    csnRepeatcy = new Long(csnRepeatcy == null ? 0l : csnRepeatcy.longValue() + touchgoCy.longValue());
			    }
			    else if("修理".equals(r.getCcType())) {
				    //非第1次，上次为“修理”的情况//
				    //A、TSN、CSN、TSO、CSO、TSN_ENGINE、CSN_REPEAT取上次对应的值
				    tsn = r.getTsn();
				    tsnEngine = r.getTsnEngine();
				    csn = r.getCsn();
				    csnRepeatcy = r.getCsnRepeat();
				    tso = r.getTso();
				    cso = r.getCso();
				
			        //B、TSR、CSR为0，TSR_CA为（本次操作的日期跟上次操作的日期之间的天数）
				    tsr = new Double(0);
				    csr = new Long(0);
				    tsrCa = new Long(d);
				
			        //C、TSN_CA、TSO_CA为上次对应的值再加上（本次操作的日期跟上次操作的日期之间的天数）
				    tsnCa = new Long(r.getTsnCa().longValue() + d);
				    tsoCa = new Long(r.getTsoCa().longValue() + d);
			    }
			    else if("大修".equals(r.getCcType())) {
				    //非第1次，上次为“大修”的情况
				    //A、TSN、CSN、TSN_ENGINE、CSN_REPEAT取上次对应的值
				    tsn = r.getTsn();
				    tsnEngine = r.getTsnEngine();
				    csn = r.getCsn();
				    csnRepeatcy = r.getCsnRepeat();
				
			        //B、TSR、CSR、TSO、CSO为0，TSR_CA、TSO_CA为（本次操作的日期跟上次操作的日期之间的天数）
				    tsr = new Double(0);
				    csr = new Long(0);
				    tso = new Double(0);
				    cso = new Long(0);
				    tsrCa = new Long(d);
				    tsoCa = new Long(d);
				
			        //C、TSN_CA为上次对应的值再加上（本次操作的日期跟上次操作的日期之间的天数）
				    tsnCa = new Long(r.getTsnCa().longValue() + d);
			    }
		    }
		
		    out.put("record", record);
		    out.put("tsn", tsn);
		    out.put("tsnEngine", tsnEngine);
		    out.put("csn", csn);
		    out.put("csnRepeatcy", csnRepeatcy);
		    out.put("tsnCa", tsnCa);
		    out.put("tsr", tsr);
		    out.put("csr", csr);
		    out.put("tsrCa", tsrCa);
		    out.put("tso", tso);
		    out.put("cso", cso);
		    out.put("tsoCa", tsoCa);
		    out.put("tsi", tsi);
		    out.put("csi", csi);
		    return out;
	    }	
        */

        #endregion

        #region 根据件号的连续循环转换率

        /** 代码参照
	    private double getRate(PartsCcRecordView record){
		
		    double fhRate = PartHardCodeConstant.PARTS_FH_CALCULATE_RATE_NORMAL;//0.5
		    String spc = record.getSpc();
		    String nhspc = record.getNhSpc();
		    if("AP".equals(nhspc) || "AP".equals(spc)){
			    String ra = "";
			    if("AP".equals(nhspc)){
				    ra = record.getNhCdc1();
			    }
			    if("AP".equals(spc)){
				    ra = record.getCdc1();
			    }
			    if(ra!="" && ra != null ){
				    fhRate = new Double(ra).doubleValue();
			    }else{
				    fhRate = 0;
			    }
		    }
		    return fhRate;
	    }
        */

        #endregion

    }
}
