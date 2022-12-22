<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Web_ThanhChucnang.ascx.cs" Inherits="web_usercontrol_WebUserControl" %>
<%--<header>--%>
<%-- <link href="../../css/owl.carousel.min.css" rel="stylesheet" />
    <link href="../../css/owl.theme.default.min.css" rel="stylesheet" />--%>
<%--<script src="../../js/jquery-3.5.1.min.js"></script>--%>
<%--<script src="../../js/jquery.min.js"></script>--%>
<%--<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.1/jquery.min.js" integrity="sha512-aVKKRRi/Q/YV+4mjoKBsE4x3H+BkegoM/em46NNlCqNTmUYADjBbeNefNxYV7giUp0VxICtqdrbqU7iVaeZNXA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>--%>
<%--<script src="../../js/owl.carousel.min.js"></script>--%>
<%--<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>--%>
<script src="../admin_js/sweetalert.min.js"></script>
<%--</header>--%>

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

    /*.block-btn {
        padding: 1% !important;
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
*/
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
    }
    function onLoad1() {
        $("#img-loading-icon").show();
        setTimeout(function () { $("#img-loading-icon").hide() }, 2000);
    }
</script>
<div class="col-12" style="padding: 0%; display: block">
    <div class="block-menu row" style="padding: 0% 1% !important;">
        <div class="owl-carousel" id="div_App">
            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-thong-bao_0" class="block-btn" href="/website-thong-bao">
                    <img src="/image/icon/thong-bao.png" />
                    <span>THÔNG BÁO</span>
                    <span class="thong-bao" id="divThongBao" runat="server"><%=sothongbao %></span>
                </a>
            </div>
            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-xin-nghi_4" class="block-btn" href="/website-xin-nghi">
                    <img src="/image/icon/Dangky-Xin-nghi.png" />
                    <span>XIN NGHỈ</span>
                </a>
            </div>
            <div class="item">
                <a onclick="funcActive(this.id),onLoad1()" class="block-btn" href="https://bambooschool.edu.vn/phan-mem-giup-be-hoc-chu-cai-tieng-viet/#ftoc-heading-1" id="HocTap_8" target="_blank">
                    <img src="/image/icon/Dangky-Hoc-tap.png" />
                    <span>HỌC TẬP</span>
                </a>
            </div>
            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-dan-thuoc_5" class="block-btn" href="/website-thong-dan-thuoc">
                    <img src="/image/icon/Dangky-Thuoc.png" />
                    <span>DẶN THUỐC
                        <br />
                        VÀ DẶN DÒ
                    </span>
                </a>
            </div>
            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-thong-tin-suc-khoe_1" class="block-btn" href="/website-thong-tin-suc-khoe">
                    <img src="/image/icon/suc-khoe.png" />
                    <span>THÔNG TIN
                        <br />
                        SỨC KHỎE</span>
                </a>
            </div>







            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-dang-ky-da-ngoai_9" class="block-btn" href="website-dang-ki-ngoai-khoa">
                    <img src="/image/icon/Dangky-ngoai-khoa.png" />
                    <span>ĐĂNG KÍ
                        <br />
                        NGOẠI KHÓA</span>
                    <span class="new" id="divDaNgoai" runat="server">New</span>
                </a>
            </div>



            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="website-vietnhatkids-an-sang-uong-sua_10" class="block-btn" href="/website-dang-ki-an-sang">
                    <img src="/image/icon/Dangky-an-sang.png" />
                    <span>ĐK VÀ HỦY
                        ĂN
                        <br />
                        SÁNG
                    </span>
                </a>

            </div>

            <div class="item">
                <a onclick="funcActive(this.id),onLoad()" id="DanhGiaGiaoVien_14" class="block-btn" href="/website-vietnhatkids-danh-gia-giao-vien">
                    <img src="/image/icon/danh-gia-giao-vien.png" />
                    <span>ĐÁNH GIÁ
                        <br />
                        GIÁO VIÊN</span>
                </a>

            </div>

        </div>
    </div>
</div>

