<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_QuenMatKhau.aspx.cs" Inherits="web_module_website_VietNhatKids_web_QuenMatKhau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--Thẻ meta--%>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
    <meta name="format-detection" content="telephone=no" />
    <meta name="full-screen" content="yes" />
    <meta name="x5-full-screen" content="true" />
    <meta name="360-full-screen" content="true" />
    <meta name="renderer" content="webkit" />
    <meta name="force-rendering" content="webkit" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="mobile-web-app-capable" content="yes" />
    <%--Thẻ meta--%>
    <link href="../../assets/css/popup-gopy.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://unpkg.com/swiper@8/swiper-bundle.min.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="../../admin_js/sweetalert.min.js"></script>
    <link rel="icon" type="image/x-icon" href="/admin_images/logo_mamnon.png" />

    <title>Trường Mầm non Việt Nhật</title>
    <style>
        /*
 * Specific styles of signin component
 */
        /*
 * General styles
 */
        body, html {
            height: 100%;
            background-image: url('/image_PHTDT/image_web/Background.png');
            display: flex;
            flex-direction: column;
            justify-content: center;
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
        }


        .card-container.card {
            max-width: 450px;
            padding: 40px 40px;
            border-radius: 10px;
            box-shadow: 3px 2px 18px #99999942;
            padding-top: 20px;
        }

        .btn {
            font-weight: 700;
            height: 36px;
            -moz-user-select: none;
            -webkit-user-select: none;
            user-select: none;
            cursor: default;
        }

        /*
 * Card component
 */
        .card {
            background-color: #F7F7F7;
            /* just in case there no content*/
            padding: 20px 25px 30px;
            margin: 0 auto 25px;
            margin-top: 35px;
            /* shadows and rounded borders */
            -moz-border-radius: 2px;
            -webkit-border-radius: 2px;
            border-radius: 2px;
            -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
            box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        }

        .profile-img-card {
            /*width: 221px;
            height: 134px;*/
                width: 35%;
            max-width: 100%;
            margin: 0 auto 10px;
            display: block;
            -moz-border-radius: 50%;
            -webkit-border-radius: 50%;
            border-radius: 34%;
        }

        /*
 * Form styles
 */
        .profile-name-card {
            font-size: 16px;
            font-weight: bold;
            text-align: center;
            margin: 10px 0 0;
            min-height: 1em;
        }

        .reauth-email {
            display: block;
            color: #404040;
            line-height: 2;
            margin-bottom: 10px;
            font-size: 14px;
            text-align: center;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }

        .form-signin #inputEmail,
        .form-signin #inputPassword {
            direction: ltr;
            height: 44px;
            font-size: 16px;
        }

        .form-signin input[type=email],
        .form-signin input[type=password],
        .form-signin input[type=text],
        .form-signin button {
            width: 100%;
            display: block;
            margin-bottom: 10px;
            z-index: 1;
            position: relative;
            -moz-box-sizing: border-box;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
        }

        .form-signin .form-control:focus {
            border-color: rgb(104, 145, 162);
            outline: 0;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075),0 0 8px rgb(104, 145, 162);
        }

        .btn.btn-signin {
            /*background-color: #4d90fe; */
            background-color: rgb(104, 145, 162);
            /* background-color: linear-gradient(rgb(104, 145, 162), rgb(12, 97, 33));*/
            padding: 0px;
            font-weight: 700;
            font-size: 14px;
            height: 36px;
            line-height: 36px;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            border: none;
            -o-transition: all 0.218s;
            -moz-transition: all 0.218s;
            -webkit-transition: all 0.218s;
            transition: all 0.218s;
        }

            .btn.btn-signin:hover,
            .btn.btn-signin:active,
            .btn.btn-signin:focus {
                background-color: rgb(12, 97, 33);
            }

        .forgot-password {
            color: rgb(104, 145, 162);
            margin-top: 2%;
        }

            .forgot-password:hover,
            .forgot-password:active,
            .forgot-password:focus {
                color: rgb(12, 97, 33);
            }

        .btn.btn-signin {
            /* background-color: #4d90fe; */
            background-color: rgb(142 25 27);
        }

            .btn.btn-signin:hover, .btn.btn-signin:active, .btn.btn-signin:focus {
                background-color: #c62828;
            }

        .icon_VietNhat a {
            display: block;
            background: url(/admin_images/VietNhat.png) 0 0 no-repeat;
            background-size: cover;
            width: 291px;
            height: 100px;
            margin: 0 auto 0px;
        }

        a:active {
            /*background:#8e191b !important;*/
            background: #c62828 !important;
            border-color: #8e191b !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div id="step1" class="card card-container">
                <img id="profile-img" class="profile-img-card" src="/image_PHTDT/image_web/logo_mamnon.png" />
                <div class="form-signin">
                    <span id="reauth-email" class="reauth-email">Vui lòng kiểm tra Email để điền mã xác nhận!</span>
                    <input runat="server" type="Text" id="txtEmail" class="form-control" placeholder="Nhập Email" />
                    <a href="#" runat="server" id="btn_Gui" onclick="return checkMail()" onserverclick="btnGui_ServerClick" class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Gửi</a>
                    <a href="/website-trang-chu" style="background-color: rgb(131 127 127)" class="btn btn-lg btn-primary btn-block btn-signin">Quay lại</a>
                </div>
            </div>
            <%-- <div id="step2" class="card card-container" style="display: none">
                <img id="profile-img2" class="profile-img-card" src="../../admin_images/logo.png" />
                <div class="form-signin">
                    <span id="reauth-email2" class="reauth-email"></span>
                    <input runat="server" type="Text" id="Text1" class="form-control" placeholder="Nhập Email" />
                    <a href="#" runat="server" id="btnGui" onclick="return checkMail()" onserverclick="btnGui_ServerClick" class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Gửi</a>

                </div>
            </div>--%>
        </div>
    </form>
    <script>      
        function checkMail() {
            var mail = document.getElementById("<%=txtEmail.ClientID%>");
            if (mail.value.trim() == "") {
                swal("Vui lòng nhập mail để nhận mật khẩu!", '', 'warning')/*.then(function () { mail.focus(); })*/;
                return false;
            }
            else {

                if (IsInvalidEmail(mail.value.trim()) == true) {
                    return true;
                }
                else {
                    swal("Email không đúng định dạng!", '', 'warning')/*.then(function () { mail.focus(); })*/;
                    return false;
                }
            }
        }

        function openForm() {
            document.getElementById("step2").style.display = "none";
        }
        function closeForm() {

            document.getElementById("step2").style.display = "none";
        }
        window.onclick = function (event) {
            if (event.target == myForm) {
                myForm.style.display = "none";
            }
        }
        //check định dạng mail
        function IsInvalidEmail(the_email) {
            var at = the_email.indexOf("@");
            var dot = the_email.lastIndexOf(".");
            var space = the_email.indexOf(" ");
            if ((at != -1) && //có ký tự @
                (at != 0) && //ký tự @ không nằm ở vị trí đầu
                (dot != -1) && //có ký tự .
                (dot > at + 1) && (dot < the_email.length - 1) //phải có ký tự nằm giữa @ và . cuối cùng
                &&
                (space == -1)) //không có khoẳng trắng 
            {
                return true;
            } else {

                return false;
            }
        }
    </script>
</body>
</html>
