USE [AYS]
GO
/****** Object:  StoredProcedure [dbo].[spMusteriWithParam]    Script Date: 8.05.2017 19:29:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spMusteriWithParam](@musteriTcKimlikNo nvarchar(11))
AS
BEGIN
SELECT        tbl_Musteriler.musteri_tc_kimlik_no as 'TC Kimlik No',
 tbl_Musteriler.musteri_adi as 'Adı',
  tbl_Musteriler.musteri_soyadi as 'Soyadı',
   tbl_Musteriler.musteri_telefon_no as 'Telefon',
    tbl_Musteriler.musteri_telefon_no2 as 'Telefon 2',
	 tbl_Musteriler.musteri_email as 'Email', 
      tbl_Musteriler.musteri_sehir as 'Şehir',
	  tbl_Musteriler.musteri_adres as 'Adres',
	   tbl_Daireler.daire_kapi_no as 'Daire Kapı No',
	   tbl_Daireler.daire_no as 'Daire No',
		tbl_Binalar.bina_adi as 'Apart Adı',
	    tbl_Musteriler.musteri_aciklama as 'Açıklama',
		 tbl_Musteriler.musteri_kontrat_baslangic_tarihi as 'Kontrat Başlangıç',
		  tbl_Musteriler.musteri_kontrat_bitis_tarihi as 'Kontrat Bitiş', 
           tbl_Musteriler.musteri_kira_tutari as 'Kira Miktarı',
		    tbl_Musteriler.musteri_yetki as 'Yetkili',
			 tbl_Musteriler.musteri_durumu as 'Durumu'
			  
FROM            tbl_Musteriler INNER JOIN
                         tbl_Daireler ON tbl_Musteriler.daire_no = tbl_Daireler.daire_no INNER JOIN
                         tbl_Binalar ON tbl_Daireler.bina_id = tbl_Binalar.bina_id
						 where tbl_Musteriler.musteri_tc_kimlik_no=@musteriTcKimlikNo
END
