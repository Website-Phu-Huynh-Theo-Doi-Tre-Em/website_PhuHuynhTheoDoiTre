<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_Login.aspx.cs" Inherits="web_module_website_web_Login" %>

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
    <title>Website - Phụ Huynh Theo Dõi Trẻ</title>
    <style>
        /*
 * Specific styles of signin component
 */
        /*
 * General styles
 */
        body, html {
            height: 100%;
            background-image: url('/image_/background-1.png');
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
            width: 151px;
            height: 134px;
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
            background-color: #4d90fe; 
           /* background-color: rgb(104, 145, 162);*/
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
                background-color: #4d90fe;
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
            background-color: #4d90fe;
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

        
    </style>
</head>
    <script>
        function searchKeyPress(e) {
            e = e || window.event;
            if (e.keyCode == 13) {
                document.getElementById('btn_Gui').click();
                return false;
            }
            return true;
        }
    </script>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="icon_VietNhat">
               <%-- <h2 style="text-align: center;">VIỆT NHẬT</h2>--%>
                <a class="logo" style="cursor: auto;"></a>
                <h6 style="text-align: center; font-size: 21px;">Đồng hành cùng phụ huynh ươm mầm tương lai</h6>
            </div>
            <div class="card card-container">
                <img id="profile-img" class="profile-img-card" src="/image_/Logo.png" />
            
                <div class="form-signin">
                    <span id="reauth-email" class="reauth-email"></span>
                    <input runat="server" type="Text" id="txtSDT" class="form-control" placeholder="Nhập số điện thoại" />
                    <input runat="server" type="password" id="txtMatKhau"  onkeypress="return searchKeyPress(event);" class="form-control" placeholder="Nhập Mật khẩu" />
                    <%--<div id="remember" class="checkbox">
                        <label>
                            <input type="checkbox" value="remember-me" />
                            <asp:CheckBox runat="server" ID="checklogin" />
                            Nhớ mật khẩu
                   
                        </label>
                    </div>--%>
                    <a href="#" runat="server" id="btn_Gui" onclick="return checkNull()" onserverclick="btn_Gui_ServerClick" class="btn btn-lg btn-primary btn-block btn-signin" type="submit">Đăng nhập </a>
                </div>
                <!-- /form -->
                <a href="/website-quen-mat-khau" class="forgot-password">Quên mật khẩu?
            </a>
            </div>
           
        </div>
    </form>
    <script>
        var input = document.getElementById("myInput");
        input.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                document.getElementById("myBtn").click();
            }
        });
    </script>
    <script>
        function checkNull() {
            var sdt = document.getElementById("<%=txtSDT.ClientID%>");
            var mk = document.getElementById("<%=txtMatKhau.ClientID%>");
            if (sdt.value.trim() == "") {
                swal("Vui lòng nhập số điện thoại đăng nhập!", '', 'warning').then(function () { sdt.focus(); });
                return false;
            }
            if (mk.value.trim() == "") {
                swal("Vui lòng nhập mật khẩu đăng nhập!", '', 'warning').then(function () { mk.focus(); });
                return false;
            }
            return true;
        }
       
    </script>
</body>
</    html>
