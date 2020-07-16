USE [dhh_db]
GO

/****** Object:  View [dbo].[vw_invoice_clients]    Script Date: 7/16/2020 5:08:57 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



alter view [dbo].[vw_invoice_clients] as
select iv.*,cd.cli_nm,cd.addr_l1,cd.phone_num,cd.mobil_num,cd.mail_addr,cd.sex_code
from tdhh_invoice_masters iv,tdhh_client_details cd
where iv.cli_num=cd.cli_num
GO


