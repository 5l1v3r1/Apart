USE [AYS]
GO
/****** Object:  StoredProcedure [dbo].[sp_yonetici_girisi]    Script Date: 4.05.2017 07:08:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_yonetici_girisi]
(
        @yonetici_adi nvarchar(50),
        @yonetici_sifresi nvarchar(12)
)
as
begin
	Select yonetici_id from tbl_Yoneticiler where yonetici_adi=@yonetici_adi and yonetici_sifresi=@yonetici_sifresi 
end
