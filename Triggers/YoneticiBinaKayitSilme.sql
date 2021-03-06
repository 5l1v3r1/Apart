USE [AYS]
GO
/****** Object:  Trigger [dbo].[BinaYoneticiKayitSilmee]    Script Date: 4.05.2017 07:07:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER trigger [dbo].[BinaYoneticiKayitSilmee] on [dbo].[tbl_Yoneticiler]
for delete
as
begin
      declare @yonetici_id int
      select @yonetici_id=yonetici_id from deleted -- silinen satisadedi ve urunid değerlerini alıyoruz.
      delete from tbl_YoneticiBina where yonetici_id=@yonetici_id --satış tablosundan silinen ürün miktarı kadar ürünü ürünler tablosunda ekliyoruz.
end