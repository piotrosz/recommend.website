TODO:

Recommendation: Localization
List of places
Recommendation rating
Recommendation category/tags (?)

Password recovery
Email confirmation after registering (?)
Profile edit
add http://mvcrecaptcha.codeplex.com/


Bootstrap style copied from: http://getbootstrap.com/examples/jumbotron/

Enable-Migrations -ProjectName Recommend.Core -StartupProjectName Recommend.Web [-Force]
Add-Migration AddedCreatedOnComputedColumns -ProjectName Recommend.Core -StartupProjectName Recommend.Web
Update-Database -ProjectName Recommend.Core -StartupProjectName Recommend.Web
Update-Database -ProjectName Recommend.Core -StartupProjectName Recommend.Web -ConnectionString -ProviderName System.Data.SqlClient


@{
    var base64 = Convert.ToBase64String(Model.ByteArray);
    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
}

<img src="@imgSrc" />

http://www.prideparrot.com/blog/archive/2012/8/uploading_and_returning_files