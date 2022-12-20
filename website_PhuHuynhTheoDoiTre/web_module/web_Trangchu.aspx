<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage_PhuHuynhTheoDoiTre.master" AutoEventWireup="true" CodeFile="web_Trangchu.aspx.cs" Inherits="website_PhuHuynhTheoDoiTre_web_module_Default3" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/web_ThanhChucNang.ascx" TagPrefix="uc1" TagName="Web_ThanhChucNang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
    <title>Giao diện web phụ huynh theo dõi trẻ</title>
    <style>
        img {
            max-width: 100%;
            min-width: 100%;
            object-fit: cover;
        }
    </style>
    <style>
        html {
            overflow-x: hidden;
        }

        .block-menu {
            box-shadow: 2px 3px 8px 5px #80808029;
            margin: 1% 0;
            height: 7rem;
            background: white;
            border-radius: 10px;
        }

        .block-btn {
            padding: 3% !important;
            display: flex;
            justify-content: center;
            flex-direction: column;
            text-align: center;
            font-size: 7px;
            font-weight: 800;
            color: #6464a9;
            box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);
            background: #d5e8ef;
            height: 6rem;
            border-radius: 10px;
        }

            .block-btn img {
                padding: 1% 14% 0 14%;
            }

        .block-menu {
            justify-content: space-between;
        }

        .pad {
            padding: 0 !important;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .thong-bao {
            position: absolute;
            background: red;
            font-size: 20px;
            z-index: 10;
            display: flex;
            left: 75%;
            bottom: 68%;
            color: white;
            width: 33px;
            box-shadow: 1px 1px 1px 1px grey;
            border-radius: 18px;
            height: 33px;
            justify-content: center;
            align-items: center;
        }

        .new {
            position: absolute;
            background: #28a745;
            font-size: 12px;
            z-index: 10;
            display: flex;
            left: 75%;
            bottom: 68%;
            color: white;
            width: 33px;
            box-shadow: 1px 1px 1px 1px grey;
            border-radius: 18px;
            height: 33px;
            justify-content: center;
            align-items: center;
        }

        .icon_next {
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

        .owl-dot {
            display: none !important;
        }

        .owl-nav {
            display: flex;
            justify-content: space-between;
        }

        button:focus {
            outline: none !important;
        }

        .owl-prev, .owl-next {
            position: absolute !important;
            background: none !important;
            border: none !important;
            color: #8e191b !important;
            font-size: 70px !important;
        }

            .owl-prev span {
                display: block;
            }

        .owl-stage-outer {
            height: 7rem;
            padding-top: 0.75%;
        }

        .owl-prev {
            top: -5%;
            left: -3% !important;
        }

        .owl-next {
            top: -5%;
            right: -3% !important;
        }

        .item a:hover {
            cursor: pointer;
            text-decoration: none;
            background-color: aqua;
            box-shadow: 0px 14px 14px rgb(0 0 0 / 25%);
        }

        .item {
            pointer-events: auto;
        }

        .block-btn span {
            font-size: 10px;
        }

        .Active {
            background-color: aqua;
            box-shadow: 2px 4px 12px 2px #1c33688f;
            color: #940808;
        }

        .owl-prev, .owl-next {
            position: absolute !important;
            background: none !important;
            border: none !important;
            color: #8e191b !important;
            font-size: 70px !important;
        }

            .owl-prev span {
                display: block;
            }

        .owl-stage-outer {
            height: 7rem;
            padding-top: 0.75%;
        }

        .owl-prev {
            top: -5%;
            left: -3% !important;
        }

        .owl-next {
            top: -5%;
            right: -3% !important;
        }

        owl-prev span {
            display: block;
        }

        .container_left {
            box-shadow: 2px 3px 8px 5px #80808029;
            margin: 1% 0;
            height: 32.3rem;
            background: white;
            border-radius: 10px;
            padding: 3%;
            text-align: justify;
            /* margin: 0; */
            /* display: flex; */
            /* flex-direction: row; */
            justify-content: flex-start;
        }
        .block-hinhdaidien {
        border-radius: 107px;
        width: 12%;
        background: #44403a4d;
         height: auto; 
        margin-top: -16.5%;
        margin-left: 5.3%;
        margin-right: 23%;
        position: absolute;
    }
    </style>
    <script>

        function funcActive(id) {
            var app = $("#div_App").find("div.owl-item.active");
            //get item đang active
            var item = $(app[0]).find('a.block-btn').attr('id');
            sessionStorage.setItem('listActive', item);
        }

        $(document).ready(function () {
            var hrefs = location.pathname.replace('/', '');
            document.querySelector('a[href="/' + hrefs + '"]').classList.add("Active");
            var position = sessionStorage.getItem("listActive").split('_');
            $("#div_App").trigger("to.owl.carousel", [position[1], 10, true])
        });
        function onLoad() {
            $("#img-loading-icon").show();
            setTimeout(function () { $("#img-loading-icon").hide() }, 2000);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

        <div class="container-fluid row">
            <div class="col-xl-3 col-md-12 float-left">
                <uc1:Web_ThongTinCaNhan runat="server" ID="Web_ThongTinCaNhan" />
            </div>
            <div class="col-xl-9 col-md-12">
                <div class="col-xl-12 col-md-12 userrp" style="padding: 0">
                    <div class="col-12" style="padding: 0%; display: block">
                        <div class="block-menu row" style="padding: 0% 1% !important;">
                            <div class="owl-carousel" id="div_App">
                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-thong-bao_0" class="block-btn" href="/website-vietnhatkids-thong-bao">
                                        <img src="/icon/thong-bao.png" />
                                        <span>THÔNG BÁO</span>
                                        <span class="thong-bao" id="divThongBao">2
                                        </span>
                                      <%--  <span class="thong-bao" id="divThongBao" runat="server"><%=sothongbao %></span>--%>
                                    </a>
                                </div>
                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-thong-tin-suc-khoe_1" class="block-btn" href="/website-vietnhatkids-thong-tin-suc-khoe">
                                        <img src="/icon/suc-khoe.png" />
                                        <span>THÔNG TIN
                        <br />
                                            SỨC KHỎE</span>
                                    </a>
                                </div>


                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-xin-nghi_4" class="block-btn" href="/website-vietnhatkids-xin-nghi">
                                        <img src="/icon/Dangky-Xin-nghi.png" />
                                        <span>XIN NGHỈ</span>
                                    </a>
                                </div>
                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-dan-thuoc_5" class="block-btn" href="/website-vietnhatkids-dan-thuoc">
                                        <img src="/icon/Dangky-Thuoc.png" />
                                        <span>DẶN DÒ
                        <br />
                                           THUỐC
                                        </span>
                                    </a>
                                </div>
                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-ablum-anh_6" class="block-btn" href="/website-vietnhatkids-ablum-anh">
                                        <img src="/icon/album.png" />
                                        <span>ALBUM ẢNH</span>
                                    </a>
                                </div>

                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" class="block-btn" href="/danh-muc-hoc-tap" id="HocTap_8">
                                        <img src="/icon/Dangky-Hoc-tap.png" />
                                        <span>HỌC TẬP</span>
                                    </a>
                                </div>
                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-dang-ky-da-ngoai_9" class="block-btn" href="/website-vietnhatkids-dang-ky-da-ngoai">
                                        <img src="/icon/Dangky-ngoai-khoa.png" />
                                        <span>ĐĂNG KÍ
                        <br />
                                            NGOẠI KHÓA</span>
                                        <span class="new" id="divDaNgoai" runat="server">New</span>
                                    </a>
                                </div>



                                <div class="item">
                                    <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-an-sang-uong-sua_10" class="block-btn" href="/website-vietnhatkids-an-sang-uong-sua">
                                        <img src="/icon/Dangky-ngoai-khoa.png" />

                                        <span>ĐĂNG KÍ
                                            <br />
                                            ĂN SÁNG
                                        </span>
                                    </a>

                                </div>


                            </div>
                        </div>
                    </div>
                    <%--  --%>
                    <div class="col-12 row " style="padding: 0; margin: 0">
                        <div class="container_left col-12 colrp" style="margin: 0">
                            <div>
                                [ 💐THÔNG BÁO CUỐI KÌ CLB 💐 ]
                                <br />
                                👉[TB1]: Thứ 6 ngày 16/12/2022 (ngày mai) chúng ta sẽ được nghỉ để ôn tập kiếm tra cuối kì CLB qua hệ thống vào thứ 3 tuần sau.<br />
                                👉[TB2]: Thứ 3 chúng ta sẽ làm bài kiểm tra cuối kì kết thúc CLB sau khi thi xong các bạn sẽ nhận lại tiền cam kết phí còn lại và nhận giấy chứng nhận CLB. CLB kết thúc khóa học.
                      <br />
                                👉[TB3]: Các bạn chú ý Group nhóm CLB qua zalo để nhận bài ôn tập và các thông báo khác.
                   <br />
                                👉[TB4]: Hướng dẫn bài tập và mọi thắc mắc liên hệ  trực tiếp thành viên CLB hoặc nhắn trực tiếp ở Group zalo.
                   <br />
                                Cảm ơn các bạn đã đồng hành CLB trong kì học vừa qua. Trân trọng!🥰
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/js/owl.carousel.min.js"></script>

</asp:Content>

