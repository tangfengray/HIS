USE [Trasen_0329]
GO
/****** Object:  Trigger [dbo].[TR_MZ_YYGHLB_UPDATEFOREVENTLOG]    Script Date: 2017/8/31 16:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

--Add By Tany 2015-09-29 更新预约信息
ALTER TRIGGER [dbo].[TR_MZ_YYGHLB_UPDATEFOREVENTLOG]
	ON [dbo].[MZ_YYGHLB] 
	AFTER UPDATE
AS   
SET NOCOUNT ON

if(UPDATE(ghxxid))
begin

	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'GetGhMsgInfo','MZ_YYGHLB',ghxxid 
	from inserted
	where ghxxid is not null

end

if(UPDATE(bscbz))
begin

	insert into EVENTLOG(EVENT,CATEGORY,BIZID) 
	select 'GetQxYyMsgInfo','MZ_YYGHLB',yyid 
	from inserted
	where bscbz=1
	-- Add By Mr.Chan 2017-08-30 限制能直接支付的平台不发送号源锁定超时预约取消短信
	and PTID not in ('1','10','11','17','18','20','30','50','60','61','63','80','90')--限制发送预约短信的渠道

end

