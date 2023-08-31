namespace BackendApiTest.Core.Utils
{
    #region path extensions

    public static class PathExtension
    {
        #region Person profile image

        public static string OriginalPersonProfileImage = "/medias/images/Person/profile/original/";

        public static string OriginalPersonProfileImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/medias/images/Person/profile/original/");

        #endregion

        #region Domain Address

        //public static string DomainAddress = "https://localhost:44367";
        public static string DomainAddress = "https://BackendApiTest.com";

        #endregion
    }

    #endregion

    #region Images Sizes

    public static class ImagesSizes
    {

    }

    #endregion

    #region image resizes information

    public static class ImageResizesInformation
    {

    }

    #endregion

    public static class FileAcceptableFormats
    {
        public static string ImageAvailableFormat = "image/png, image/jpeg, image/webp";
    }
}