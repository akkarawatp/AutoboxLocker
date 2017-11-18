function asyncVDO(KO_ID,  fulVDO) {

    var ful = $("#" + fulVDO);
    var filename = ful.val();

    var filecontent = ful.prop("files")[0];

    if (filecontent.size > (100 * 1024 * 1024)) {
        //alert("ไฟล์ที่อัพโหลดต้องไม่เกิน 12 Mb");
        alert("File size must not larger than 100MB");
        return;
    }

    if (!VDOFileNameValid(filename)) return;

    var formData = new FormData();
    formData.append("filecontent", filecontent);
    sendPostDataToURLUploadVDO("frmScreenSaverUpload.aspx?KO_ID="+KO_ID, formData);
}

function VDOFileNameValid(filename) {
    var lastDot = filename.lastIndexOf(".");
    var lastSlash = filename.lastIndexOf("\\");

    //Firefox=Windows NT 10.0; WOW64; rv:46.0) Gecko/20100101 Firefox/46.0
    //ถ้า navigator.userAgent เป็น Firefox ให้กำหนดค่า lastSlash = 1 เลย
    var browserDetail = navigator.userAgent;
    if (browserDetail.indexOf("Firefox") != -1) {
        lastSlash = 1;
    }

    if (lastDot == -1 || lastSlash == -1) {
        //alert('รูปแบบชื่อไฟล์ไม่ถูกต้อง\n\nระบบรองรับไฟล์ภาพประเภท png jpg jpeg หรือ gif เท่านั้น');
        alert("Support only avi");
        return false;
    }
    var ext = filename.substring(lastDot + 1, filename.length).toLowerCase();
    switch (ext) {
        case 'mp4':
        case 'avi': return true;
        default:
            alert("Support only avi");
            return false;
    }
}

function sendPostDataToURLUploadVDO(url, formData) {
    $.ajax({
        url: url,
        type: 'POST',
        success: function () { alert("Upload Complete"); },
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    });
}


function asyncAdsEdit(objId, RowIndex) {
    
    var ful = $(objId);
    var filename = ful.val();
    if (filename.trim() == "")
        return;

    var filecontent = ful.prop("files")[0];
    
    if (filecontent.size > (12 * 1024 * 1024)) {
        //alert("ไฟล์ที่อัพโหลดต้องไม่เกิน 12 Mb");
        alert("File size must not larger than 12MB");
        return;
    } 
    if (!inFileNameValid(filename)) return;
    var formData = new FormData();
    formData.append("filecontent", filecontent);
    sendPostDataToURLUpdateAds("Ads_Upload.aspx?Mode=Update&R=" + RowIndex, formData);
}

function asyncAdsInsert() {
    var ful = $("#fulInsertAds");
    var filename = ful.val();
    //alert(filename + ful);

    if (filename.trim() == "")
        return;

    var filecontent = ful.prop("files")[0];
    if (filecontent.size > (12 * 1024 * 1024)) {
        //alert("ไฟล์ที่อัพโหลดต้องไม่เกิน 12 Mb");
        alert("File size must not larger than 12MB");
        return false;
    }
    if (!inFileNameValid(filename)) return;
    var formData = new FormData();
    formData.append("filecontent", filecontent);
    sendPostDataToURLUpdateAds("Ads_Upload.aspx?Mode=Insert", formData);
}

function sendPostDataToURLUpdateAds(url, formData) {
    $.ajax({
        url: url,
        type: 'POST',
        success: function () { $("#btnUpdateAds").click(); },
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    });
}

function asyncBundledProductIconUpload(lang) {

    var ful = $("#ful" + lang);
    var filename = ful.val();
    var filecontent = ful.prop("files")[0];
    if (filecontent.size > (12 * 1024 * 1024)) {
        //alert("ไฟล์ที่อัพโหลดต้องไม่เกิน 12 Mb");
        alert("File size must not larger than 12MB");
        return;
    }
    if (!inFileNameValid(filename)) return;
    var formData = new FormData();
    formData.append("filecontent", filecontent);
    sendPostDataToURLUpdateBundledProduct("BundledProduct_Icon_Upload.aspx?lang=" + lang, formData, lang);
}

function sendPostDataToURLUpdateBundledProduct(url,formData,lang) {
    $.ajax({
        url: url,
        type: 'POST',
        success: function () { $("#btnUpdateIcon" + lang).click(); },
        data: formData,
        cache: false,
        contentType: false,
        processData: false
    });
}

function inFileNameValid(filename) {
    var lastDot = filename.lastIndexOf(".");
    var lastSlash = filename.lastIndexOf("\\");
    
    //Firefox=Windows NT 10.0; WOW64; rv:46.0) Gecko/20100101 Firefox/46.0
    //ถ้า navigator.userAgent เป็น Firefox ให้กำหนดค่า lastSlash = 1 เลย
    var browserDetail = navigator.userAgent;
    if (browserDetail.indexOf("Firefox") != -1) {
        lastSlash = 1;
    }

    if (lastDot == -1 || lastSlash == -1) {
        //alert('รูปแบบชื่อไฟล์ไม่ถูกต้อง\n\nระบบรองรับไฟล์ภาพประเภท png jpg jpeg หรือ gif เท่านั้น');
        alert("Support only image jpeg gif png 1");
        return false;
    }

    var ext = filename.substring(lastDot + 1, filename.length).toLowerCase();
    switch (ext) {
        case 'jpg':
        case 'jpeg':
        case 'png':
        case 'gif':return true;
        default:
            //alert('รูปแบบชื่อไฟล์ไม่ถูกต้อง\n\nระบบรองรับไฟล์ภาพประเภท png jpg jpeg หรือ gif เท่านั้น');
            alert("Support only image jpeg gif png 2");
            return false;
    }
}

function requireTextboxDialog(url, width, height, TextboxClientID, HiddenButtonClientID) {
    if (url.toString().indexOf('?') != url.toString().length - 1) url += "?";
    window.open(url + "&txt=" + TextboxClientID + "&btn=" + HiddenButtonClientID, "", "height=" + height + ",width=" + width + ",center=true,scrollbars,resizable");
}

function returnSelectedValue(value, TextboxClientID, HiddenButtonClientID) {
    if ((!opener)) { window.close(); return; }
    if (TextboxClientID != "") {
        var txt = opener.document.getElementById(TextboxClientID);
        if (!txt) { } else { txt.value = value; }
    }
    if (HiddenButtonClientID != '') {
        var btn = opener.document.getElementById(HiddenButtonClientID);
        if (!btn) { } else { btn.click(); }
    }
    window.close(); opener.focus();
}

function openPrintWindow(url, width, height) {
    window.open(url, "", "height=" + height + ",width=" + width + ",center=true,scrollbars,resizable");
}

function openCamWindow(ko_id, width, height) {
    window.open("CamPlayer.aspx?K=" + ko_id, "Cam_Kiosk_" + ko_id, "height=" + height + ",width=" + width + ",center=true,scrollbars,resizable");
}

function addCommas(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

function formatmoney(input, minvalue, maxvalue) {
    var firstch = '';
    if (input != '') {
        switch (input.substr(0, 1)) {
            case "+":
            case "-": firstch = input.substr(0, 1);
                break;
        }
    }
    var tmp = parseFloat(replaceComma(input).replace('-', '').replace('+', ''));
    if (tmp.toString().toUpperCase() == 'NAN') return '';

    //Check Min Max
    if ((minvalue != '') && (tmp < minvalue)) tmp = minvalue;
    if ((maxvalue != '') && (tmp > maxvalue)) tmp = maxvalue;
    return firstch + addCommas(Number(tmp).toFixed(2));
}

function formatinteger(input, minvalue, maxvalue) {
    var firstch = '';
    if (input != '') {
        switch (input.substr(0, 1)) {
            case "+":
            case "-": firstch = input.substr(0, 1);
                break;
        }
    }

    var tmp = parseFloat(replaceComma(input).replace('-', '').replace('+', ''));
    if (tmp.toString().toUpperCase() == 'NAN') return '';

    //Check Min Max
    if ((minvalue != '') && (tmp < minvalue)) tmp = minvalue;
    if ((maxvalue != '') && (tmp > maxvalue)) tmp = maxvalue;

    return firstch + addCommas(Number(tmp).toFixed(0));
}

function formatfloat(input, minvalue, maxvalue) {
    var firstch = '';
    if (input != '') {
        switch (input.substr(0, 1)) {
            case "+":
            case "-": firstch = input.substr(0, 1);
                break;
        }
    }
    var tmp = parseFloat(replaceComma(input).replace('-', '').replace('+', ''));
    if (tmp.toString().toUpperCase() == 'NAN') return '';

    //Check Min Max
    if ((minvalue != '') && (tmp < minvalue)) tmp = minvalue;
    if ((maxvalue != '') && (tmp > maxvalue)) tmp = maxvalue;
    var part = tmp.toString().split(".");
    tmp = part[0];
    var decpart = "";
    if (part.length > 1) {
        decpart = part[1];
        while (decpart.substr(decpart.length - 1, 1) == '0')
            decpart = decpart.substr(0, decpart.length - 1);
    }
    var result = firstch + addCommas(Number(tmp).toFixed(0));
    if (decpart != '') result += '.' + decpart
    return result;
}

function formatonlynumber(input) {
    var result = '';
    for (i = 0; i < input.length; i++) {
        switch (input.toString().substr(i, 1)) {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9": result += input.toString().substr(i, 1);
                break;
        }
    }
    return result;
}

function replaceComma(input) {
    while (input.toString().indexOf(",") > -1) input = input.replace(",", "");
    return input
}

function preventCalendarMinDate(mindate, txtClientId, captionText) {
    if (txtClientId == '' || mindate == '') return;

    var txt = document.getElementById(txtClientId);
    if (!txt) return;
    if (txt.value < mindate) {
        alert(captionText + " must be " + mindate + " or later");
        txt.value = '';
    }
}

function preventCalendarMinDateNotClearText(mindate, txtClientId, captionText, oldValue) {
    if (txtClientId == '' || mindate == '') return;

    var txt = document.getElementById(txtClientId);
    if (!txt) return;
    if (txt.value < mindate) {
        alert(captionText + " must be " + mindate + " or later");
        txt.value = oldValue;
    }
}


function IsEngDate(thedate) {
    var _tmp = thedate.split('/');
    if (_tmp.length != 3) return false;
    if (parseInt(_tmp[0]) > 31 || parseInt(_tmp[0]) < 1) return false;
    if (parseInt(_tmp[1]) > 12 || parseInt(_tmp[1]) < 1) return false;
    if (parseInt(_tmp[2]) < 1900 || parseInt(_tmp[2]) > 2100) return false;
    return true;
}

function IsThaiDate(thedate) {
    var _tmp = thedate.split('/');
    if (_tmp.Length != 3) return false;
    if (parseInt(_tmp[0]) > 31 || parseInt(_tmp[0]) < 1) return false;
    if (parseInt(_tmp[1]) > 12 || parseInt(_tmp[1]) < 1) return false;
    if (parseInt(_tmp[2]) < 2500 || parseInt(_tmp[2]) > 2600) return false;
    return true;
}

function EngToThaiDate(thObj, enObj) {

    if (!IsEngDate(enObj.value)) {
        thObj.value = '';
        return;
    }
    var _tmp = enObj.value.split('/');
    thObj.value = _tmp[0] + "/" + _tmp[1] + "/" + (parseInt(_tmp[2]) + 543);
}

/*------------Start Freezing Header Contained id='fixedPageHeader'-------------*/
var _fixedPageHeaderPageAbsY;
var _fixedPageHeaderpageAbsX;
var _hfixedOffsetWidth;
var _fixedPageHeader;

function createHeaderExtent() {
    var hfixed = document.getElementById("fixedPageHeader");
    /*insert element first time only*/
    if (!document.getElementById("headerExtent")) {
        hfixed.outerHTML += "<div id='headerExtent' class='row-fluid' style='visibility:hidden; z-Index:2;'></div>";
        var _extent = document.getElementById("headerExtent");

        var _part1 = hfixed.innerHTML.substr(0, hfixed.innerHTML.indexOf('<ul '));
        var _part2 = hfixed.innerHTML.substr(hfixed.innerHTML.indexOf('</ul>'));
        _extent.innerHTML = (_part1 + _part2).replace('<!-- END PAGE TITLE & BREADCRUMB-->', '<hr>');
        _extent.style.backgroundColor = 'white';
        _extent.style.position = 'fixed';
    }
}

function getFreezePaneVar() {
    var hfixed = document.getElementById("fixedPageHeader");
    var _extent = document.getElementById("headerExtent");
    var _part1 = hfixed.innerHTML.substr(0, hfixed.innerHTML.indexOf('<ul '));
    var _part2 = hfixed.innerHTML.substr(hfixed.innerHTML.indexOf('</ul>'));
    _extent.innerHTML = (_part1 + _part2).replace('<!-- END PAGE TITLE & BREADCRUMB-->', '<hr>');
    _fixedPageHeaderPageAbsY = getAbsoluteY(hfixed);
    _fixedPageHeaderpageAbsX = getAbsoluteX(hfixed);
}

function freezeHeaderClient() {
    var hfixed = document.getElementById("fixedPageHeader");
    if (!hfixed) return;
    createHeaderExtent();
    /*---------------calculate on the fly--------------*/
    getFreezePaneVar();
    var _extent = document.getElementById("headerExtent");
    var yThreshold = parseInt(_fixedPageHeaderPageAbsY);
    var scrollY = parseInt(window.scrollY);
    if (scrollY > yThreshold) {
        _extent.style.visibility = 'visible';
        _extent.style.left = _fixedPageHeaderpageAbsX + 'px';
        if (window.innerWidth <= 960) {
            _extent.style.top = '0px';
            _extent.style.width = '100%';
        }
        else {
            _extent.style.top = _fixedPageHeaderPageAbsY + 'px';
            _extent.style.width = _hfixedOffsetWidth + 'px';
        }
    }
    else
    { hideExtentHeader(); }
}

function freezeHeaderAfterPostback() {
    var hfixed = document.getElementById("fixedPageHeader");
    if (!hfixed) return;
    createHeaderExtent();
    /*---------------don't need to calculate global variable--------------*/
    getFreezePaneVar();
    var _extent = document.getElementById("headerExtent");
    var yThreshold = parseInt(_fixedPageHeaderPageAbsY);
    var scrollY = parseInt(window.scrollY);
    if (scrollY > yThreshold) {
        _extent.style.visibility = 'visible';
        _extent.style.left = _fixedPageHeaderpageAbsX + 'px';
        if (window.innerWidth <= 960) {
            _extent.style.top = '0px';
            _extent.style.width = '100%';
        }
        else {
            _extent.style.top = _fixedPageHeaderPageAbsY + 'px';
            _extent.style.width = _hfixedOffsetWidth + 'px';
        }
    }
    else
    { hideExtentHeader(); }
}

$(document).ready(freezeHeaderClient); /*--------Page load-----------*/
$(document).scroll(freezeHeaderClient); /*--------scrollbar-----------*/
$(window).resize(freezeHeaderClient); /*--------Resize-----------*/


function hideExtentHeader() {
    var _extent = document.getElementById("headerExtent");
    if (!_extent) return;
    _extent.style.visibility = 'hidden';
}

function getAbsoluteX(oElement) {
    var xReturnValue = 0;
    while (oElement != null) {
        xReturnValue += oElement.offsetLeft;
        oElement = oElement.offsetParent;
    }
    //At this point you can 'return' the values as well
    return xReturnValue;
}

function getAbsoluteY(oElement) {
    var yReturnValue = 0;
    while (oElement != null) {
        yReturnValue += oElement.offsetTop;
        oElement = oElement.offsetParent;
    }
    //At this point you can 'return' the values as well
    return yReturnValue;
}
/*------------End Freezing Header Contained id='fixedPageHeader'-------------*/


function ChkMinusDbl(ctl, e) {
    //var evt = e ? e : window.event; 
    var zz = e.keyCode || e.charCode;

    if (zz < 48 || zz > 57) {
        if (zz == 46) {
            if (ctl.value.indexOf(".", 0) >= 0) {
                if (window.event) {//IE 
                    var ieVersion = parseFloat(navigator.appVersion);
                    if (ieVersion == 5)  //IE 9, 10 
                        e.preventDefault();
                    else if (ieVersion == 4)  //IE 7,8 
                        event.returnValue = false;
                } else if (e) {//Firefox 
                    e.preventDefault();
                }
            }
        }
        else {
            if (window.event) {//IE 
                var ieVersion = parseFloat(navigator.appVersion);
                if (ieVersion == 5)  //IE 9, 10 
                    e.preventDefault();
                else if (ieVersion == 4)  //IE 7,8 
                    event.returnValue = false;
            } else if (e) {//Firefox 
                e.preventDefault();
            }
        }


    }
}


function ChkMinusInt(ctl, e) {
    //var evt = e ? e : window.event; 
    var zz = e.keyCode || e.charCode;

    if (zz < 48 || zz > 57) {
        if (window.event) {//IE 
            var ieVersion = parseFloat(navigator.appVersion);
            if (ieVersion == 5)  //IE 9, 10 
                e.preventDefault();
            else if (ieVersion == 4)  //IE 7,8 
                event.returnValue = false;
        } else if (e) {//Firefox 
            e.preventDefault();
        }
    }
}


function CheckKeyNumber(e) {
    //삯系⊥묀櫓〈쀼窪  ctrl 笑剋陌졔饑 V 
    var evt = e ? e : window.event;
    var keyCode = evt.keyCode || evt.charCode;

    if ((keyCode == 17) || (keyCode == 86)) {
        if (window.event) {//IE 
            var ieVersion = parseFloat(navigator.appVersion);
            //alert(ieVersion); 
            if (ieVersion == 5)  //IE 9, 10 
                e.preventDefault();
            else if (ieVersion == 4)  //IE 7,8 
                event.returnValue = false;
        } else if (e) {//Firefox 
            e.preventDefault();
        }
    }
}
