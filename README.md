# Sitecore-Foundation-Media-Plugin
To get the allowed media plugin up and running, follow steps-

Install package
Set the file type and size you want to allow in your Sitecore instance in following file- Website\App_Config\Include\Pipelines\Sitecore.Foundation.MediaPlugin.config
Upload file in Media Library and plugin should allow only file types and size set in config.
Done

To set the allowed file type and size add/update fileconfig elements in Website\App_Config\Include\Pipelines\Sitecore.Foundation.MediaPlugin.config-

    <mediaplugin type="Sitecore.Foundation.MediaPlugin.Models.MediaConfig, Sitecore.Foundation.MediaPlugin">
      <mediapluginconfig hint="raw:AddFileConfig">
        <fileconfig extension="jpg" sizeallowed="2" sizeunit="mb" mediatype="image"/>
        <fileconfig extension="png" sizeallowed="2" sizeunit="mb" mediatype="image"/>
        <fileconfig extension="gif" sizeallowed="2" sizeunit="mb" mediatype="image"/>
        <fileconfig extension="pdf" sizeallowed="3" sizeunit="mb" mediatype="file"/>
        <fileconfig extension="doc" sizeallowed="20" sizeunit="mb" mediatype="file"/>
        <fileconfig extension="docx" sizeallowed="20" sizeunit="mb" mediatype="file"/>
        <fileconfig extension="mp4" sizeallowed="4" sizeunit="mb" mediatype="file"/>
      </mediapluginconfig>
    </mediaplugin>
