USE [AYS]
GO

/****** Object:  StoredProcedure [dbo].[spGelirListesi]    Script Date: 8.05.2017 00:51:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spGelirListesi]
as
begin
SELECT        tbl_Binalar.bina_adi as 'Apart Ad�', tbl_Daireler.daire_kapi_no as 'Daire Kap� No', tbl_Musteriler.musteri_adi as 'Ad�'
				, tbl_Musteriler.musteri_soyadi as 'Soyad�', tbl_Gelir.gelir_tutari as 'Gelir Tutar�', tbl_Gelir.gelir_tarihi as  'Gelir Tarihi', 
				tbl_GelirTuru.gelir_adi as 'Gelir T�r�'
FROM            tbl_GelirTuru INNER JOIN
                         tbl_Gelir ON tbl_GelirTuru.gelir_turu_id = tbl_Gelir.gelir_turu_id INNER JOIN
                         tbl_Musteriler ON tbl_Gelir.musteri_tc_kimlik_no = tbl_Musteriler.musteri_tc_kimlik_no INNER JOIN
                         tbl_Binalar INNER JOIN
                         tbl_Daireler ON tbl_Binalar.bina_id = tbl_Daireler.bina_id ON tbl_Musteriler.daire_no = tbl_Daireler.daire_no
end
GO


