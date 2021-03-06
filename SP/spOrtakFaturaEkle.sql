USE [AYS]
GO
/****** Object:  StoredProcedure [dbo].[spFaturaOrtakEkle]    Script Date: 11.05.2017 03:02:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spFaturaOrtakEkle](@binaAdi nvarchar(50),@aboneNo varchar(50),@ortak1 int,@ortak2 int,@sonuc int output)
as
begin
	declare @binaId int =(select bina_id from tbl_Binalar where bina_adi=@binaAdi)
	declare @daireNo1 int =CASE when @ortak1=0 Then 0 else (select daire_no from tbl_Daireler where bina_id=@binaId and daire_kapi_no= @ortak1) end
	declare @daireNo2 int =CASE when @ortak2=0 Then 0 else (select daire_no from tbl_Daireler where bina_id=@binaId and daire_kapi_no= @ortak2) end

	if @daireNo1 != 0
	begin
	INSERT INTO [dbo].[tbl_OrtakFatura]
           ([fatura_abone_no]
           ,[daire_no])
     VALUES
           (@aboneNo,@daireNo1)
	end
	if @daireNo2 != 0
	begin
	INSERT INTO [dbo].[tbl_OrtakFatura]
           ([fatura_abone_no]
           ,[daire_no])
     VALUES
           (@aboneNo,@daireNo2)
	end
	set @sonuc = (select tbl_FaturaAboneNo.fatura_id from tbl_FaturaAboneNo where tbl_FaturaAboneNo.fatura_abone_no=@aboneNo)
	return
end

