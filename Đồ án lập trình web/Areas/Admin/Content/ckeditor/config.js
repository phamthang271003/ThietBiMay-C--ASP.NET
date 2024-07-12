/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	//config.language = 'vi';
    //config.uiColor = '#AADC6E';
    config.enterMode = CKEDITOR.ENTER_BR;
    config.toolbar = 'Full';
    config.filebrowserBrowseUrl = '/Areas/Admin/Content/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Areas/Admin/Content/ckfinder/ckfinder.html?type=Images';
    config.filebrowserFlashBrowseUrl = '/Areas/Admin/Content/ckfinder/ckfinder.html?type=Flash';
    config.filebrowserUploadUrl = '/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
    config.filebrowserFlashUploadUrl = '/Areas/Admin/Content/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.filebrowserWindowWidth = '1000';
    config.filebrowserWindowHeight = '700';
};
