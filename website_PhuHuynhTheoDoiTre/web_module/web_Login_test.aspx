<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_Login_test.aspx.cs" Inherits="website_PhuHuynhTheoDoiTre_web_module_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="/css/css_PhuHuynhTheoDoiTre/Login_Register.css" rel="stylesheet" />
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <title>Website-Phụ Huynh Theo Dõi Trẻ</title>
    <style>
        .text_TaiKhoan {
            display: flex;
            flex-direction: column;
            flex-wrap: nowrap;
            width: 86%;
            margin: 1% 2%;
            text-align: justify;
        }

    </style>
     <script>
         

     </script>
</head>
<body>
    <div class="container">
        <div class="formBox level-login">
            <div class="box boxShaddow"></div>
            <div class="box loginBox">
                <h2>ĐĂNG NHẬP</h2>
                <form class="form">
                    <div class="f_row">
                        <label>Tài khoản:</label>
                        <input type="text" class="input-field" runat="server" id="txtUsername" />
                        <u></u>
                    </div>
                    <div class="f_row last">
                        <label>Mật khẩu:</label>
                        <input type="password" class="input-field" runat="server" id="txtPassword" />
                        <u></u>
                    </div>

                    <a href="/website_PhuHuynhTheoDoiTre/web_module/web_Trangchu.aspx" class="btn"  type="submit" runat="server" id="btnDangNhap" onserverclick="btnDangNhap_ServerClick" onclick="return checkNull()"> 
                        <span>ĐĂNG NHẬP</span><u></u>
                    </a>
                    <div class="f_link">
                        <a href="#" class="resetTag">Quên mật khẩu</a>
                    </div>
                </form>
            </div>
            <div class="box forgetbox">
                <a href="#" class="back icon-back">
                    
                </a>
                <h2>ĐỔI MẬT KHẨU</h2>
                <form class="form">
                    <p>Nhập địa chỉ Email mà bạn đã đăng kí cho học sinh ở trường.Và kiểm tra Email để nhận mã.</p>
                    <div class="f_row last">
                        <label>Email</label>
                        <input type="text" class="input-field" />
                        <u></u>
                    </div>
                    <a href="#" class="btn">
                        <span>Đổi mật khẩu</span><u></u>
                    </a>
                </form>
            </div>
            <div class="box registerBox">
                <span class="reg_bg"></span>
                <h2>TÀI KHOẢN</h2>
                <form class="form">
                    <div class="text_TaiKhoan">
                        <p>
                            Nếu chưa có tài khoản hãy liên hệ giáo viên chủ nhiệm của bé để được cấp tài khoản.Cảm ơn quý phụ huynh!
                        </p>
                    </div>

                </form>
            </div>
            <a href="#" class="regTag icon-add">
                <svg version="1.1" id="Capa_2" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px" viewBox="0 0 357 357" style="enable-background: new 0 0 357 357;" xml:space="preserve">
                    <path d="M357,204H204v153h-51V204H0v-51h153V0h51v153h153V204z" />
                </svg>

            </a>
        </div>
    </div>
    <script>
        var inP = $(".input-field");

        inP
            .on("blur", function () {
                if (!this.value) {
                    $(this).parent(".f_row").removeClass("focus");
                } else {
                    $(this).parent(".f_row").addClass("focus");
                }
            })
            .on("focus", function () {
                $(this).parent(".f_row").addClass("focus");
                $(".btn").removeClass("active");
                $(".f_row").removeClass("shake");
            });

        $(".resetTag").click(function (e) {
            e.preventDefault();
            $(".formBox").addClass("level-forget").removeClass("level-reg");
        });

        $(".back").click(function (e) {
            e.preventDefault();
            $(".formBox").removeClass("level-forget").addClass("level-login");
        });

        $(".regTag").click(function (e) {
            e.preventDefault();
            $(".formBox").removeClass("level-reg-revers");
            $(".formBox").toggleClass("level-login").toggleClass("level-reg");
            if (!$(".formBox").hasClass("level-reg")) {
                $(".formBox").addClass("level-reg-revers");
            }
        });
        $(".btn").each(function () {
            $(this).on("click", function (e) {
                e.preventDefault();

                var finp = $(this).parent("form").find("input");

                console.log(finp.html());

                if (!finp.val() == 0) {
                    $(this).addClass("active");
                }

                setTimeout(function () {
                    inP.val("");

                    $(".f_row").removeClass("shake focus");
                    $(".btn").removeClass("active");
                }, 2000);

                if (inP.val() == 0) {
                    inP.parent(".f_row").addClass("shake");
                }

                //inP.val('');
                //$('.f_row').removeClass('focus');
            });
        });

    </script>
</body>
</html>


