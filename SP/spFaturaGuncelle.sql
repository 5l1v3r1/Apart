USE [AYS]
GO
/****** Object:  StoredProcedure [dbo].[spFaturaGuncelle]    Script Date: 11.05.2017 03:01:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spFaturaGuncelle](@faturaId int,@faturaTuru nvarchar(50),@binaAdi nvarchar(50),@aboneNo varchar(50),@sonuc int output)
as
begin
	
	declare @faturaTuruId int =(select fatura_turu_id from tbl_FaturaTuru where fatura_adi=@faturaTuru)
	declare @binaId int =(select bina_id from tbl_Binalar where bina_adi=@binaAdi)
	UPDATE [dbo].[tbl_FaturaAboneNo]
            set [fatura_abone_no] =@aboneNo
           ,[bina_id]=@binaId
           ,[fatura_turu_id]=@faturaTuruId
    where tbl_FaturaAboneNo.fatura_id=@faturaId

	set @sonuc = (select tbl_FaturaAboneNo.fatura_id from tbl_FaturaAboneNo where tbl_FaturaAboneNo.fatura_abone_no=@aboneNo)
	return
end

