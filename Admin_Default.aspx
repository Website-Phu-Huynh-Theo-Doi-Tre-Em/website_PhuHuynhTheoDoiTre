<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="Admin_Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <link href="web_VietNhatKids_css/chart.css" rel="stylesheet" />
    <link href="css/lo-trinh.css" rel="stylesheet" />
    <script>
        function myDuyet(id) {
            document.getElementById("<%=txtThongBao_id.ClientID%>").value = id
            document.getElementById("<%=btnXem.ClientID%>").click();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <style>
        .link__icon {
            position: relative;
        }

        .icon__new {
            background-color: transparent;
            width: 30px;
            height: 30px;
            position: absolute;
            top: -28px;
            right: 13px;
        }

        canvas {
            padding: 2%;
        }

        .container {
            background: white;
            margin-top: 4%;
            border-radius: 12px;
            padding-top: 4%;
            box-shadow: 0px -1px 11px -1px #8080804f;
        }

        .new-item {
            width: 35px;
            height: 20px;
            background-color: #fbc531;
            position: absolute;
            z-index: 1;
            top: -28px;
            right: 9px;
            border-top-right-radius: 7px;
            text-align: center;
            color: #fff;
            font-weight: 700;
            font-size: 13px;
        }

            .new-item:before {
                content: "";
                border-width: 10px;
                border-style: solid;
                border-color: #fbc531 transparent #fbc531 transparent;
                position: absolute;
                top: 0;
                left: -11px;
            }

            .new-item:after {
                content: "";
                border-width: 9px;
                border-style: solid;
                border-color: transparent transparent transparent #fbc531;
                position: absolute;
                top: 10px;
                right: -10px;
                z-index: -1 !important;
            }

        .link__icon {
            text-decoration: none !important;
        }

        .btn-grad {
            font-size: 133%;
            font-weight: bold;
            /* height: 168%; */
            width: 96%;
            margin: 5%;
            padding: 11px;
            
            transition: 0.5s;
            background-size: 200% auto;
            color: white;
            box-shadow: 0 0 20px #eee;
            border-radius: 10px;
            display: block;
            justify-content: space-evenly;
        }


            .btn-grad:hover {
                background-position: right center;
                color: #fff;
                text-decoration: none;
            }

        .box-progress-bar {
            width: 100%;
            height: 4px;
            border-radius: 6px;
            overflow: hidden;
            background-color: #ffffff40;
            margin: 8px 0;
        }

        .box-progress {
            display: block;
            height: 4px;
            border-radius: 6px;
        }

        .box-progress-header {
            text-align: start;
            font-size: 14px;
            font-weight: 500;
            line-height: 16px;
            margin-top: 8%;
            margin: 8% 0 0 0;
        }

        .box-progress-percentage {
            text-align: right;
            margin: 0;
            font-size: 14px;
            font-weight: 500;
            line-height: 16px;
        }

        .percent_progress {
            background-color: #ffff;
        }

        .icon-new {
            position: absolute;
            width: 43px;
            left: 138px;
            top: 0px;
            z-index: 10;
        }

        .chuaxem {
            display: none;
        }

        .daxem {
            display: block;
        }

        .chart {
            display: flex;
        }

        /*#myChartbaogiang {
            width: 37.5rem !important
        }

        #myCharttuan {
            width: 37.5rem !important
        }*/

        #myChartthang, #myCharttuan, #myChartnhanxet, #myChartbaogiang {
            background-color: #ffeb3b1c;
            margin: 1%;
            border-radius: 10px;
            box-shadow: 1px 2px 5px -2px grey;
        }

        @media screen and (max-width: 992px) {
            .chart {
                margin: 0 10%;
                display: flex;
                flex-direction: column;
            }
        }

        @media screen and (max-width: 1392px) {
            .chart {
                /*max-width: 33rem;*/
            }
        }

        @media screen and (max-width: 1324px) {
            .chart {
                /*max-width: 30rem;*/
            }
        }

        @media screen and (max-width: 1144px) {
            .chart {
                /*max-width: 26rem;*/
            }
        }

        @media screen and (max-width: 1084px) {
            .chart {
                max-width: 13.5rem;
            }
        }

        @media screen and (max-width: 1163px) {
            .chart {
                max-width: 26rem;
            }
        }

        @media screen and (max-width: 1097px) {
            .chart {
                max-width: 22rem;
            }
        }

        @media screen and (max-width: 1250px) {
            .chart {
                max-width: 28rem;
            }
        }


        .table-bordered thead th {
            background: antiquewhite;
            border-bottom-width: 2px;
            color: black
        }

        .table-bordered thead td {
            background: white;
            text-align: center;
            color: blue;
            font-size: 16px;
            font-weight: 600;
        }

        .form-group {
            overflow-y: auto;
            margin: 35px 0;
            height: 29rem;
        }

        .main-omt {
            border: 1px solid #32c5d2;
            background-color: #fff;
        }

            .main-omt .omt-header {
                background-color: #32c5d2;
                padding: 4px 7px;
                display: flex;
            }

        .omt-header .header-title {
            padding: 10px 10px;
            color: white;
        }

        .omt-header .omt__icon {
            font-size: 35px;
            padding: 5px 10px;
            color: white;
        }

        .thongkegiaovien {
            text-align: center;
        }

        .item_giaovien {
            display: block;
            float: left;
            width: 120px;
            height: 130px;
            margin: 5px;
            border: 1px solid #742a2aa6;
            text-align: center;
            border-radius: 10px;
        }

            .item_giaovien img {
                width: 82%;
                padding-top: 5px;
            }

        .header {
            z-index: 0;
        }

        .thead-diem tr {
            color: dimgrey;
            font-weight: 400;
        }

            .thead-diem tr th {
                background: antiquewhite;
            }

        .omt tr td {
            text-align: center !important;
        }

        .thead-diem tr {
            text-align: start;
        }
    </style>
    <script>
        window.onload = function () {
            //hiện % số người xem ở lịch công tác tuần
            var percent_lcttuan = document.getElementById("percent_lcttuan").value;
            var percent_lctthang = document.getElementById("percent_lctthang").value;
            var tong_user = document.getElementById("tong_user").value;
            var percent_xem_lcttuan = (parseInt(percent_lcttuan) / parseInt(tong_user)) * 100;
            var percent_xem_lctthang = (parseInt(percent_lctthang) / parseInt(tong_user)) * 100;
            var elememts = document.getElementById("myBar");
            elememts.style.width = percent_xem_lcttuan + "%";
            document.getElementById("LCTThang").style.width = percent_xem_lctthang + "%";
            //tính % phiên chế năm học
            //var phienche = document.getElementById("percent_pcnh")
            //if (phienche != undefined) {
            //    var sophienche = phienche.value;
            //    var tongkhoi = document.getElementById("tong_khoi").value;
            //    var percent_phienche = (parseInt(sophienche) / parseInt(tongkhoi)) * 100;
            //    document.getElementById("PCNH").style.width = percent_phienche + "%";
            //}
            // tinh phien che quản trị
            var phienche_quantri = document.getElementById("percent_pcnh_quantri");
            if (phienche_quantri != undefined) {
                var sophienche_quantri = phienche_quantri.value;
                var tongkhoi_quantri = document.getElementById("tong_khoi_quantri").value;
                var percent_phienche_quantri = (parseInt(sophienche_quantri) / parseInt(tongkhoi_quantri)) * 100;
                document.getElementById("PCNH_quantri").style.width = percent_phienche_quantri + "%";
            }
            //tính lịch báo giảng quản trị
            var lbg_quantri = document.getElementById("lbg_gvdn_quantri");
            if (lbg_quantri != undefined) {
                var gv_danhap = lbg_quantri.value;
                var tong_giaovien = document.getElementById("tong_gv_quantri").value;
                var percent_lichbaogiang_quantri = (parseInt(gv_danhap) / parseInt(tong_giaovien)) * 100;
                document.getElementById("lichbaogiang_quantri").style.width = percent_lichbaogiang_quantri + "%";
            }
            //tính lịch báo giảng cơ sở
            var lbg_quantri = document.getElementById("lbg_gvdn_coso");
            if (lbg_quantri != undefined) {
                var gv_danhap = lbg_quantri.value;
                var tong_giaovien = document.getElementById("tong_gv_coso").value;
                var percent_lichbaogiang_coso = (parseInt(gv_danhap) / parseInt(tong_giaovien)) * 100;
                document.getElementById("lichbaogiang_coso").style.width = percent_lichbaogiang_coso + "%";
            }
            //tinh kế hoạch dạy học
            //var kehoachdaduyet = document.getElementById("percent_kh_daduyet");
            //if (kehoachdaduyet != undefined) {
            //    var kh = kehoachdaduyet.value;
            //    var tongkhoi = document.getElementById("tong_khoi").value;
            //    var percent_kehoachdayhoc = (parseInt(kh) / parseInt(tongkhoi)) * 100;
            document.getElementById("KHDH_quantri").style.width = "100%";
            //}
        }
        //func show modal chi tiết xem lịch công tác tháng
        function showModal() {
            document.getElementById("btnShowModal").click();
        }

    </script>

    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
    </script>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <div class="finbyz-timeline" id="div_CongViecHangNgay" runat="server">
        <div class="container">
            <div class="row" style="height: 37rem;">
                <div style="font-size: 40PX; font-weight: bold; text-align: center; color: darkblue; padding-bottom: 3%;">CÔNG VIỆC HẰNG NGÀY</div>
                <div data-vc-full-width="true" data-vc-full-width-init="true" class="vc_row wpb_row vc_row-fluid vc_custom_1542873226451 vc_row-has-fill wgl-row-animation" style="display: contents; /* left: -11.2px; */
    box-sizing: border-box; width: 1002px; position: relative;">
                    <div class="wpb_column vc_column_container vc_col-sm-12">
                        <div class="vc_column-inner ">
                            <div class="wpb_wrapper">
                                <div class="seofy_module_time_line_vertical appear_anim col-6">
                                    <asp:Repeater ID="rpCongViec" runat="server">
                                        <ItemTemplate>
                                            <div class="time_line-item  item_show <%#Eval("mau") %> col-12">
                                                <div class="time_line-date_wrap">
                                                    <div class="seofy_hexagon">
                                                        <h4 class="time_line-date" style="font-size: 36px"><%#Eval("danhsachcongviec_id") %></h4>
                                                        <svg style="fill: #ffa705;" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 177.4 197.4">
                                                            <path d="M0,58.4v79.9c0,6.5,3.5,12.6,9.2,15.8l70.5,40.2c5.6,3.2,12.4,3.2,18,0l70.5-40.2c5.7-3.2,9.2-9.3,9.2-15.8V58.4 c0-6.5-3.5-12.6-9.2-15.8L97.7,2.4c-5.6-3.2-12.4-3.2-18,0L9.2,42.5C3.5,45.8,0,51.8,0,58.4z"></path></svg>
                                                    </div>
                                                    <div class="seofy_hexagon">
                                                        <svg style="filter: drop-shadow(4px 5px 4px rgba(255,167,5,0.3)); fill: #ffa705;" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 177.4 197.4">
                                                            <path d="M0,58.4v79.9c0,6.5,3.5,12.6,9.2,15.8l70.5,40.2c5.6,3.2,12.4,3.2,18,0l70.5-40.2c5.7-3.2,9.2-9.3,9.2-15.8V58.4 c0-6.5-3.5-12.6-9.2-15.8L97.7,2.4c-5.6-3.2-12.4-3.2-18,0L9.2,42.5C3.5,45.8,0,51.8,0,58.4z"></path></svg>
                                                    </div>
                                                </div>
                                                <a href="<%#Eval("danhsachcongviec_link") %>" class="time_line-content" style="display: flex; text-decoration: none; align-items: center;">
                                                    <h5 class="time_line-title"><%#Eval("danhsachcongviec_name") %></h5>
                                                    <div class="time_line-descr"><%#Eval("danhsachcongviec_content") %></div>
                                                </a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div id="seofy_spacer_5cf90ca8190c4" class="seofy_module_spacing responsive_active" style="display: none">
                                    <div class="spacing_size spacing_size-initial" style="height: 76px;"></div>
                                    <div class="spacing_size spacing_size-tablet" style="height: 65px;"></div>
                                </div>
                            </div>
                        </div>
                        <!-- Modal -->
                        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                            <div class="modal-dialog modal-dialog-centered" role="document" style="max-width: 100%; width: 888px;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="exampleModalLongTitle">Bảng tính điểm tích lũy</h5>
                                        <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>--%>
                                    </div>
                                    <div class="modal-body">
                                        <table class="table">
                                            <thead class="thead-diem">
                                                <tr>
                                                    <th>STT</th>
                                                    <th>Nội dung</th>
                                                    <th>Điểm</th>
                                                    <th>Ghi chú</th>
                                                </tr>
                                                <tr>
                                                    <td>1</td>
                                                    <td>Tính điểm cho các công việc hằng ngày </td>
                                                    <td style="color: red;">1 điểm / 1 công việc</td>
                                                    <td>Chỉ tính điểm cho giáo viên điểm danh lần đầu tiên trong 1 ngày, giáo viên sau vào cập nhật sẽ không cộng điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>2</td>
                                                    <td>Tính điểm tạo bài viết hàng tuần (tối thiểu 2 đến 3 bài 1 tuần)</td>
                                                    <td style="color: red;">3 điểm / 1 bài viết</td>
                                                    <td>Các cô tạo bài viết được + 3 điểm, nhưng khi xóa bài viết thì sẽ bị trừ 3 điểm. Vì sẽ tính điểm thi đua, nên các cô không nên xóa các bài viết cũ.</td>
                                                </tr>
                                                <tr>
                                                    <td>3</td>
                                                    <td>Tính điểm tạo album cá nhân</td>
                                                    <td style="color: red;">5 điểm / 1 bài viết</td>
                                                    <td>Vì tạo hình ảnh riêng cá nhân của bé, nên chức này sẽ được +5 điểm và sẽ tăng lên trong thời gian tới.</td>
                                                </tr>
                                                <tr>
                                                    <td>4</td>
                                                    <td>Tính điểm tạo lịch báo giảng </td>
                                                    <td style="color: red;">3 điểm / 1 lịch báo giảng</td>
                                                    <td>Mỗi lần các cô tạo lịch sẽ được + 3 điểm nhưng nếu xóa bài viết chưa duyệt thì sẽ bị -3 điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>5</td>
                                                    <td>Tính điểm xác nhận dặn thuốc</td>
                                                    <td style="color: red;">1 điểm / 1 xác nhận</td>
                                                    <td>Khi bấm nút xác nhận dặn thuốc từ phía phụ huynh gửi qua thì +1 điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>6</td>
                                                    <td>Tính điểm xác nhận xin nghỉ</td>
                                                    <td style="color: red;">1 điểm / 1 xác nhận</td>
                                                    <td>Khi bấm nút xác nhận xin nghỉ từ phía phụ huynh gửi qua thì +1 điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>7</td>
                                                    <td>Tính điểm xác nhận đăng kí ngoại khóa</td>
                                                    <td style="color: red;">1 điểm / 1 xác nhận</td>
                                                    <td>Khi bấm nút xác nhận đăng kí ngoại khóa từ phía phụ huynh gửi qua thì +1 điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>8</td>
                                                    <td>Tính điểm tạo thông báo trường</td>
                                                    <td style="color: red;">3 điểm / 1 thông báo </td>
                                                    <td>Tạo thông báo lớp người chịu trách nhiệm sẽ được +3 điểm, nếu xóa bài viết thì sẽ bị trừ -3 điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>9</td>
                                                    <td>Tính điểm tạo thông báo lớp</td>
                                                    <td style="color: red;">3 điểm / 1 thông báo</td>
                                                    <td>Tạo thông báo lớp giáo viên sẽ được +3 điểm, nếu xóa bài viết thì sẽ bị trừ -3 điểm</td>
                                                </tr>
                                                <tr>
                                                    <td>10</td>
                                                    <td>Tính điểm duyệt thông báo lớp</td>
                                                    <td style="color: red;">1 điểm / 1 xác nhận</td>
                                                    <td>Khi giáo viên tạo thông báo lớp, người chịu trách nhiệm duyệt thông báo lớp sẽ + 1 điểm</td>
                                                </tr>
                                            </thead>
                                        </table>
                                        <%--</div>--%>
                                        <%-- <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                        <button type="button" class="btn btn-primary">Save changes</button>
                                    </div>--%>
                                        <button type="button" class="btn btn-success" data-dismiss="modal" style="margin: 2%; width: 96%;">Đóng</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div>
                                <a href="#" data-toggle="modal" class="btn btn-danger" data-target="#exampleModalCenter" style="margin-top: 1%;"><i class="fa fa-exclamation-triangle" aria-hidden="true"><span style="font-family: system-ui; font-weight: 700;">Cách tính điểm tích lũy</span></i></a>
                                <asp:DropDownList ID="ddlThang" runat="server" onchange="DisplayLoadingIcon()" OnSelectedIndexChanged="ddlThang_SelectedIndexChanged" AutoPostBack="true" CssClass="ml-2">
                                    <asp:ListItem Value="Chọn tháng" Text="Chọn tháng" />
                                    <asp:ListItem Value="01" Text="Tháng 01" />
                                    <asp:ListItem Value="02" Text="Tháng 02" />
                                    <asp:ListItem Value="03" Text="Tháng 03" />
                                    <asp:ListItem Value="04" Text="Tháng 04" />
                                    <asp:ListItem Value="05" Text="Tháng 05" />
                                    <asp:ListItem Value="06" Text="Tháng 06" />
                                    <asp:ListItem Value="07" Text="Tháng 07" />
                                    <asp:ListItem Value="08" Text="Tháng 08" />
                                    <asp:ListItem Value="09" Text="Tháng 09" />
                                    <asp:ListItem Value="10" Text="Tháng 10" />
                                    <asp:ListItem Value="11" Text="Tháng 11" />
                                    <asp:ListItem Value="12" Text="Tháng 12" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group table-responsive col-6">
                                <table class="table table-bordered">
                                    <thead class="thead-omt">
                                        <tr>
                                            <th>STT</th>
                                            <th>Tên giáo viên</th>
                                            <th>Tổng điểm</th>
                                            <th>Chi tiết</th>
                                        </tr>
                                        <asp:Repeater ID="rpTongDiemTichLuyGiaoVien" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Container.ItemIndex+1 %></td>
                                                    <td style="text-align: left"><%#Eval("username_fullname") %></td>
                                                    <td><%#Eval("diemtichluy") %></td>
                                                    <td><a class="btn btn-success" href="javascript:void(0)" data-toggle="modal" data-target="#exampleModal<%#Eval("username_id") %>">Xem</a></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--  <tr>
                                        <td>1</td>
                                        <td>2</td>
                                        <td>3</td>
                                        <td><a class="btn btn-success" href="#">Xem</a></td>
                                    </tr>--%>
                                    </thead>
                                </table>
                                <asp:Repeater ID="rpGiaoVienNhaXetThuongXuyen" runat="server" OnItemDataBound="rpGiaoVienNhaXetThuongXuyen_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="modal fade" id="exampleModal<%#Eval("username_id") %>" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                            <div class="modal-dialog" style="max-width: 100%; width: 888px; background: white;" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h2><%#Eval("username_fullname") %></h2>
                                                    </div>
                                                </div>
                                                <div class="modal-body">
                                                    <table class="table table-bordered">
                                                        <thead class="thead-omt omt">
                                                            <tr>
                                                                <th scope="col">#</th>
                                                                <th scope="col">Công việc hằng ngày</th>
                                                                <th scope="col">Dặn thuốc</th>
                                                                <th scope="col">Tạo bài viết Album</th>
                                                                <th scope="col">Xin nghỉ</th>
                                                                <th scope="col">Tạo thông báo lớp </th>
                                                                <th scope="col">Tạo thông báo trường </th>
                                                                <th scope="col">Duyệt thông báo lớp </th>
                                                                <%--<th scope="col">Tạo album cá nhân </th>--%>
                                                                <th scope="col">Tạo lịch báo giảng </th>
                                                                <th scope="col">Đăng ký ngoại khóa </th>

                                                            </tr>
                                                        </thead>
                                                        <tbody style="text-align: center">
                                                            <asp:Repeater ID="rpChiTietNhanXetHangNgay" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <th><%#Container.ItemIndex+1 %></th>
                                                                        <td><%#Eval("diemtichluychitiet_congviechangngay") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_DanThuoc") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_TaoBaiViet") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_XinNghi") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_TaoThongBaoLop") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_TaoThongBaoTruong") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_DuyetThongBaoLop") %></td>
                                                                        <%--<td><%#Eval("diemtichluychitiet_TaoAlbumCaNhan") %></td>--%>
                                                                        <td><%#Eval("diemtichluychitiet_TaoLichBaoGiang") %></td>
                                                                        <td><%#Eval("diemtichluychitiet_XacNhanNgoaiKhoa") %></td>


                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <button type="button" class="btn btn-success" data-dismiss="modal" style="margin: 2%; width: 96%;">Đóng</button>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>

                    </div>
                    <%--<div id="particles_5cf90ca81976a" class="particles-js" style="top: 0%; left: 0%; width: 30%; height: 100%;" data-particles-type="hexagons" data-particles-number="30" data-particles-color="#ff7e00,#3224e9,#69e9f2" data-particles-line="false" data-particles-size="10" data-particles-speed="1" data-particles-hover="true" data-particles-hover-mode="grab" data-particles-colors-type="random_colors">
                        <canvas class="particles-js-canvas-el" width="376" height="1636" style="width: 100%; height: 100%;"></canvas>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <%-- <marquee>
                <b>Kế hoạch dạy học đã cập nhật phiên bản mới vào ngày 14/8/2021 | lịch báo giảng đã cập nhật phiên bản mới vào ngày 17/8/2021
                </b>

            </marquee>--%>
            <%--điểm danh nhận xét hằng ngày--%>
            <div class="col-12">
                <div id="div_DiemDanhNhanXetHangNgay" runat="server">
                    <div class="title" style="text-align: center;">THỐNG KÊ GIÁO VIÊN NHẬN XÉT NGÀY <%=DateTime.Now.ToShortDateString() %></div>
                    <input type="date" id="dteNgay" runat="server" />
                    <a href="javascript:void(0)" id="btnXemThongKeNhanXetHangNgay" runat="server" class="btn btn-primary" onserverclick="btnXemThongKeNhanXetHangNgay_ServerClick">Xem</a>
                    <div class="tab-content card card-block thongkegiaovien">
                        <asp:Repeater ID="rpDiemDanhHangNgay" runat="server">
                            <ItemTemplate>
                                <a href="#" data-toggle="modal" data-target="#exampleModal<%#Eval("username_id") %>">
                                    <div class="item_giaovien">
                                        <img src="<%#Eval("username_avatar") %>" />
                                        <span style="font-size: 20px; font-weight: bold; color: #000"><%#Eval("SoLuongDiemDanhHangNgay")%>/<%#Eval("TongSoLuongDiemDanhHangNgay")%></span>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rpGiaoVienNhanXetThuongXuyen" runat="server" OnItemDataBound="rpGiaoVienNhanXetThuongXuyen_ItemDataBound">
                            <ItemTemplate>
                                <div class="modal fade" id="exampleModal<%#Eval("username_id") %>" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h2><%#Eval("username_fullname") %> - Lớp <%#Eval("lop_name") %></h2>
                                            </div>
                                            <div class="modal-body">
                                                <table class="table table-bordered">
                                                    <thead class="thead-omt">
                                                        <tr>
                                                            <th scope="col">#</th>
                                                            <th scope="col">Công việc</th>
                                                            <th scope="col">Thời gian</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rpChiTietNhanXetHangNgay" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <th><%#Container.ItemIndex+1 %></th>
                                                                    <th><%#Eval("danhsachcongviec_name") %></th>
                                                                    <td><%#Eval("lichsu_date") %></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <button type="button" class="btn btn-success" data-dismiss="modal" style="margin: 2%; width: 96%;">Đóng</button>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="text-align: center">
                <div style="font-size: 20PX; font-weight: bold; text-align: center">LỊCH CÔNG TÁC</div>
                <hr />
                <div style="margin-bottom: 20px" class="col-lg-3 col-md-4 col-sm-6 col-12">
                    <div id="div_LichCongTacCoSo" runat="server">
                        <asp:Repeater ID="rpLichCongTacTuan" runat="server">
                            <ItemTemplate>
                                <div>
                                    <a class="link__icon" href="#" id="btnXemLichCongTacTuanCoSo" runat="server" onserverclick="btnXemLichCongTacTuanCoSo_ServerClick">
                                        <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #673ab7 0%, #0530ff 51%, #5700ff 100%);" alt="Lịch có tác tuần">
                                            LỊCH CÔNG TÁC <%#Eval("lichcongtac_tuan").ToString().Split('(')[0].ToUpper() %>
                                            <p class="box-progress-header">Số người đã xem</p>
                                            <div class="box-progress-bar">
                                                <span class="box-progress percent_progress" id="myBar"></span>
                                            </div>
                                            <input type="text" value="<%#Eval("songuoixem") %>" id="percent_lcttuan" style="display: none" />
                                            <input type="text" value="<%#Eval("tonggiaovien") %>" id="tong_user" style="display: none" />
                                            <p class="box-progress-percentage"><%#Eval("songuoixem") %>/<%#Eval("tonggiaovien") %></p>
                                        </div>
                                        <img class="icon-new <%#Eval("thongbaomoi") %>" src="admin_images/icon-new2.png" />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="rpLichCongTacThang" runat="server">
                            <ItemTemplate>
                                <div>
                                    <a class="link__icon" href="#" id="btnXemLichCongTacThangCoSo" runat="server" onserverclick="btnXemLichCongTacThangCoSo_ServerClick">
                                        <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #ff9b04 0%, #ff5605 51%, #ff9700 100%);" alt="Lịch công tác tháng">
                                            LỊCH CÔNG TÁC <%#Eval("image_link").ToString().ToUpper() %>
                                            <p class="box-progress-header">Số người đã xem</p>
                                            <div class="box-progress-bar">
                                                <span class="box-progress percent_progress" id="LCTThang"></span>
                                            </div>
                                            <input type="text" value="<%#Eval("songuoixem") %>" id="percent_lctthang" style="display: none" />
                                            <p class="box-progress-percentage"><%#Eval("songuoixem") %>/<%#Eval("tonggiaovien") %></p>
                                        </div>

                                        <img class="icon-new <%#Eval("thongbaomoi") %>" src="admin_images/icon-new2.png" />
                                    </a>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater runat="server" ID="rpPhienCheNamHoc">
                            <ItemTemplate>
                                <a class="link__icon" href="/admin-xem-phien-che-nam-hoc">
                                    <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #3fff00 0%, #33cb01 51%, #3bbd04 100%)">
                                        PHIÊN CHẾ NĂM HỌC  <%#Eval("namhoc_nienkhoa") %>
                                        <p class="box-progress-header">Phiên chế đã nhập</p>
                                        <div class="box-progress-bar">
                                            <span class="box-progress percent_progress" id="PCNH_quantri"></span>
                                        </div>
                                        <input type="text" value="<%#Eval("phienchedanhap") %>" id="percent_pcnh_quantri" style="display: none" />
                                        <input type="text" value="<%#Eval("tongkhoi") %>" id="tong_khoi_quantri" style="display: none" />
                                        <p class="box-progress-percentage"><%#Eval("phienchedanhap") %>/<%#Eval("tongkhoi") %></p>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div id="div_LichCongTac_QuanTri" runat="server">
                        <a class="link__icon" href="/admin-xem-lich-cong-tac-hang-tuan">
                            <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #673ab7 0%, #0530ff 51%, #5700ff 100%);" alt="Lịch có tác tuần">
                                LỊCH CÔNG TÁC TUẦN
                                <p class="box-progress-header">&nbsp;</p>
                                <div class="box-progress-bar">
                                    <span class="box-progress percent_progress" id="myBar"></span>
                                </div>
                                <%-- <input type="text" value="<%#Eval("songuoixem") %>" id="percent_lcttuan" style="display: none" />
                                <input type="text" value="<%#Eval("tonggiaovien") %>" id="tong_user" style="display: none" />--%>
                                <p class="box-progress-percentage">&nbsp;</p>
                            </div>
                        </a>
                        <a class="link__icon" href="/admin-xem-lich-cong-tac-thang">
                            <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #ff9b04 0%, #ff5605 51%, #ff9700 100%);" alt="Lịch công tác tháng">
                                LỊCH CÔNG TÁC THÁNG
                                <p class="box-progress-header">&nbsp;</p>
                                <div class="box-progress-bar">
                                    <span class="box-progress percent_progress" id="LCTThang"></span>
                                </div>
                                <%--<input type="text" value="<%#Eval("songuoixem") %>" id="percent_lctthang" style="display: none" />--%>
                                <p class="box-progress-percentage">&nbsp;</p>
                            </div>
                        </a>
                        <asp:Repeater runat="server" ID="rpPhienCheNamHocQuanTri">
                            <ItemTemplate>
                                <a class="link__icon" href="/admin-xem-phien-che-nam-hoc">
                                    <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #3fff00 0%, #33cb01 51%, #3bbd04 100%)">
                                        PHIÊN CHẾ NĂM HỌC  <%#Eval("namhoc_nienkhoa") %>
                                        <p class="box-progress-header">Phiên chế đã nhập</p>
                                        <div class="box-progress-bar">
                                            <span class="box-progress percent_progress" id="PCNH_quantri"></span>
                                        </div>
                                        <input type="text" value="<%#Eval("phienchedanhap") %>" id="percent_pcnh_quantri" style="display: none" />
                                        <input type="text" value="<%#Eval("tongkhoi") %>" id="tong_khoi_quantri" style="display: none" />
                                        <p class="box-progress-percentage"><%#Eval("phienchedanhap") %>/<%#Eval("tongkhoi") %></p>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <br />
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="text-align: center">
                <div style="font-size: 20PX; font-weight: bold; text-align: center">
                    THỜI KHÓA BIỂU<%-- CHÍNH KHÓA - LỊCH BÁO GIẢNG - TKB TIẾT 8--%>
                    <%--  <br />
                    (Lưu ý:  TKB tiết 8 đã cập nhật mới bắt đầu từ ngày 29/03/2021)--%>
                </div>
                <hr />
                <div style="margin-bottom: 20px;" class="col-lg-3 col-md-4 col-sm-6 col-12">
                    <div id="div_KeHoachDayHoc" runat="server">
                        <asp:Repeater runat="server" ID="rpKeHoachDayHoc">
                            <ItemTemplate>
                                <a class="link__icon" href="../../admin-xem-ke-hoach-day-hoc-da-duyet">
                                    <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #673ab7 0%, #0530ff 51%, #5700ff 100%);" alt="kế hoạch dạy học">
                                        KẾ HOẠCH DẠY HỌC
                                        <p class="box-progress-header">Kế hoạch đã duyệt</p>
                                        <div class="box-progress-bar">
                                            <span class="box-progress percent_progress" id="KHDH_quantri"></span>
                                        </div>
                                        <input type="text" value="<%#Eval("keHoach_DaDuyet") %>" id="percent_kh_daduyet" style="display: none" />
                                        <input type="text" value="<%#Eval("tongkhoi") %>" id="tong_khoi" style="display: none" />
                                        <p class="box-progress-percentage"><%#Eval("keHoach_DaDuyet") %></p>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%--đối với quản trị--%>
                    <div id="div_LichBaoGiangQuanTri" runat="server">
                        <asp:Repeater runat="server" ID="rpLichBaoGiangQuanTri">
                            <ItemTemplate>
                                <a class="link__icon" href="#" id="btnLichBaoGiangQuanTri" runat="server" onserverclick="btnLichBaoGiangQuanTri_ServerClick">
                                    <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #ff9b04 0%, #ff5605 51%, #ff9700 100%);" alt="Lịch báo giảng">
                                        LỊCH BÁO GIẢNG
                                        <p class="box-progress-header">&nbsp;</p>
                                        <div class="box-progress-bar">
                                            <span class="box-progress percent_progress" id="lichbaogiang_quantri"></span>
                                        </div>
                                        <p class="box-progress-percentage">&nbsp;</p>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <%--đối với cơ sở--%>
                    <div id="div_LichBaoGiangCoSo" runat="server">
                        <asp:Repeater runat="server" ID="rpLichBaoGiangCoSo">
                            <ItemTemplate>
                                <a class="link__icon" href="#" id="btnLichBaoGiangCoSo" runat="server" onserverclick="btnLichBaoGiangCoSo_ServerClick">
                                    <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #ff9b04 0%, #ff5605 51%, #ff9700 100%);" alt="Lịch báo giảng">
                                        LỊCH BÁO GIẢNG
                            <p class="box-progress-header">&nbsp;</p>
                                        <div class="box-progress-bar">
                                            <span class="box-progress percent_progress" id="lichbaogiang_coso"></span>
                                        </div>
                                        <input type="text" value="100" id="lbg_gvdn_coso" style="display: none" />
                                        <input type="text" value="100" id="tong_gv_coso" style="display: none" />
                                        <p class="box-progress-percentage">&nbsp;</p>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <a class="link__icon" href="../../admin-thoi-khoa-bieu-tiet-8">
                        <%--<img class="" style="width: 250px; height: 58px;" src="/admin_images/tbk__images/TKB-Tiet8.png" />--%>
                        <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #3fff00 0%, #33cb01 51%, #3bbd04 100%)">
                            CÂU LẠC BỘ
                             <p class="box-progress-header">Số câu lạc bộ</p>
                            <div class="box-progress-bar">
                                <span class="box-progress percent_progress" id="LCTThang"></span>
                            </div>
                            <p class="box-progress-percentage">2</p>
                        </div>
                    </a>
                </div>
                <br />
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" style="text-align: center">
                <div style="font-size: 20PX; font-weight: bold; text-align: center">KHO TƯ LIỆU</div>
                <hr />
                <div class="col-lg-4 col-md-4 col-sm-6 col-12">
                    <a class="link__icon" href="../../kho-tu-lieu-chung">
                        <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #673ab7 0%, #0530ff 51%, #5700ff 100%)" alt="Thời khóa biểu">
                            KHO TƯ LIỆU CHUNG
                             <p class="box-progress-header">&nbsp;</p>
                            <div class="box-progress-bar">
                                <span class="box-progress percent_progress"></span>
                            </div>
                            <p class="box-progress-percentage">&nbsp;</p>
                        </div>
                        <%--<img class="" style="width: 250px; height: 60px;" src="admin_images/tu-lieu-chung.png" alt="" />--%>
                    </a>
                    <div id="div_KhoTuLieu_CS1" runat="server">
                        <a class="link__icon" href="../../kho-tu-lieu-co-so-1">
                            <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #ff9b04 0%, #ff5605 51%, #ff9700 100%)" alt="Lịch báo giảng">
                                KHO TƯ LIỆU CƠ SỞ 1
                         <p class="box-progress-header">&nbsp;</p>
                                <div class="box-progress-bar">
                                    <span class="box-progress percent_progress"></span>
                                </div>
                                <p class="box-progress-percentage">&nbsp;</p>
                            </div>
                        </a>
                    </div>
                    <div id="div_KhoTuLieu_CS2" runat="server">
                        <a class="link__icon" href="../../kho-tu-lieu-co-so-2">
                            <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #3fff00 0%, #33cb01 51%, #3bbd04 100%)">
                                KHO TƯ LIỆU  CƠ SỞ 2
                             <p class="box-progress-header">&nbsp;</p>
                                <div class="box-progress-bar">
                                    <span class="box-progress percent_progress"></span>
                                </div>
                                <p class="box-progress-percentage">&nbsp;</p>
                            </div>
                        </a>
                    </div>
                    <div id="div_KhoTuLieu_CS3" runat="server">
                        <a class="link__icon" href="../../kho-tu-lieu-co-so-3">
                            <div class="btn-grad" style="box-shadow: 0px 0px 7px #888892; background-image: linear-gradient(to right, #673ab7 0%, #0530ff 51%, #5700ff 100%)">
                                KHO TƯ LIỆU CƠ SỞ 3
                                <p class="box-progress-header">&nbsp;</p>
                                <div class="box-progress-bar">
                                    <span class="box-progress percent_progress"></span>
                                </div>
                                <p class="box-progress-percentage">&nbsp;</p>
                            </div>
                        </a>
                    </div>
                    <br />
                </div>
                <div class="col-12" style="display: none">
                    <div style="font-size: 20PX; font-weight: bold; text-align: center">
                        Địa điểm dạy tiết 8 cho lễ hội thể thao:
                <asp:Label ID="lblTuan" runat="server"></asp:Label>
                    </div>
                    <hr />
                    <div style="background: #fff">
                        <asp:UpdatePanel ID="upLoc" runat="server">
                            <ContentTemplate>
                                <div class="form-group row">
                                </div>
                                <table id="example" class="display nowrap table-hover table-bordered" style="width: 100%; text-align: center">
                                    <thead>
                                        <tr style="text-align: center; height: 40px">
                                            <th style="text-align: center">Ngày\Địa điểm</th>
                                            <th style="text-align: center">Sân bóng đá</th>
                                            <th style="text-align: center">Sân bóng rổ</th>
                                            <th style="text-align: center">Sân cầu lông</th>
                                            <th style="text-align: center">Hội trường tầng 1</th>
                                            <th style="text-align: center">Hội trường tầng 6 bên ngoài</th>
                                            <th style="text-align: center">Hội trường tầng 6 bên trong</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpBookRoom" runat="server" OnItemDataBound="rpBookRoom_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#Eval("lichbookphongthongminh_name") %></td>
                                                    <asp:Repeater ID="rpChiTiet" runat="server">
                                                        <ItemTemplate>
                                                            <td><a href="#" class="btn btn-<%#Eval("lichbookphongchitiet_class") %>" data-toggle="modal"><%#Eval("giaovien") %></a></td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <br />
                </div>
                <%--   Thông báo khẩn câp--%>
                <div style="font-size: 20PX; font-weight: bold; text-align: center; display: none">THÔNG BÁO TRONG TUẦN</div>
                <%-- <hr />--%>
                <div class="col-lg-3 col-md-4 col-sm-6 col-12" style="display: none">
                    <table class="table table-bordered table-hover" style="background-color: white">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Tiêu đề</th>
                                <th scope="col">Ngày thông báo</th>
                                <th scope="col">#</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpList" runat="server">
                                <ItemTemplate>
                                    <th scope="row"><%=STT++ %></th>
                                    <td><%#Eval("thongbao_name") %> </td>
                                    <td style="text-align: center"><%#Convert.ToDateTime(Eval("thongbao_datecreate")).ToShortDateString()%></td>
                                    <td style="text-align: center"><a class="btn btn-primary" style="color: white" id="btnDuyet" onclick="myDuyet(<%#Eval("thongbao_id") %>)">Xem</a></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <div style="display: none">
                    <input type="text" id="txtThongBao_id" runat="server" />
                    <a href="#" id="btnXem" runat="server" onserverclick="btnXem_ServerClick"></a>
                </div>
                <br />
                <%-- Thời khóa biểu của từng giáo viên--%>
                <div id="dvThoiKhoaBieu" runat="server" style="display: none">
                    <div style="font-size: 20PX; font-weight: bold; text-align: center">Thời khóa biểu</div>
                    <hr />
                    <div class="col-lg-3 col-md-4 col-sm-6 col-12">
                        <table class="table table-bordered" style="background-color: white">
                            <thead>
                                <tr class="head_table">
                                    <%-- <th class="table_header" scope="col">Buổi</th>--%>
                                    <th scope="col">Tiết</th>
                                    <th scope="col">Thứ 2</th>
                                    <th scope="col">Thứ 3</th>
                                    <th scope="col">Thứ 4</th>
                                    <th scope="col">Thứ 5</th>
                                    <th scope="col">Thứ 6</th>
                                    <%--   <th scope="col">Thứ 7</th>--%>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpThoiKhoaBieu" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="tiet" style="text-align: center"><%#Eval("tkb_tiet") %></td>
                                            <td class="tiet" style="text-align: center"><%#Eval("tkb_thu2") %></td>
                                            <td class="tiet" style="text-align: center"><%#Eval("tkb_thu3") %></td>
                                            <td class="tiet" style="text-align: center"><%#Eval("tkb_thu4") %></td>
                                            <td class="tiet" style="text-align: center"><%#Eval("tkb_thu5") %></td>
                                            <td class="tiet" style="text-align: center"><%#Eval("tkb_thu6") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <br />
            </div>
        </div>

        <div id="div_ThongKe" runat="server">
            <div class="title" style="text-align: center;">THỐNG KÊ ĐỐI VỚI GIÁO VIÊN</div>
            <div style="display: flex; justify-content: space-around;">
                <div class="chart" style="width: 100%">
                    <canvas id="myChartthang" style="width: 100%; max-width: 600px"></canvas>

                </div>
                <div class="chart" style="width: 100%">
                    <canvas id="myCharttuan" style="width: 100%"></canvas>
                </div>
            </div>

            <div style="display: flex; justify-content: space-around;">
                <div class="chart" style="width: 100%">
                    <canvas id="myChartnhanxet" style="width: 100%; max-width: 600px"></canvas>
                </div>
                <div class="chart" style="width: 100%">
                    <canvas id="myChartbaogiang" style="width: 100%"></canvas>
                </div>
            </div>
            <a href="/admin-thong-ke-tuong-tac-cua-phu-huynh" class="btn btn-primary">Thống kê tương tác phụ huynh dành cho giáo viên</a>
            <div id="div_SucKhoeHocSinh" runat="server">
                <asp:Repeater runat="server" ID="rpDanhSachHocSinhSucKhoe">
                    <ItemTemplate>
                        <div class="col-2">
                            <input type="checkbox" id="hsId_<%#Eval("hocsinh_id") %>" value="<%#Eval("hocsinh_id") %>" />
                            <label for="hsId_<%#Eval("hocsinh_id") %>" style="font-weight: normal"><%#Eval("hocsinh_name") %></label>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <label class="btn btn-primary" runat="server" id="btnDanhSachSucKhoe"
                    onclick="btnDanhSachHocSinh()">
                    Xem</label>
                <a href="#" id="btnShowSucKhoe" runat="server" onserverclick="btnShowSucKhoe_ServerClick"></a>
                <div class="chart">
                    <canvas id="myChartSucKhoeCanNang" style="width: 100%;"></canvas>
                </div>
            </div>
            <%--<div class="chart">
                <canvas id="myChartSucKhoeChieuCao" style="width: 100%;"></canvas>
            </div>--%>
        </div>
        <div style="display: none">
            ds lct tháng
            <input type="text" id="txtDSLichCongTacThang" runat="server" />
            ds số người xem lct tháng
            <input type="text" id="txtDSSoNguoiXem_LCT_Thang" runat="server" />
            ds lct tháng id
            <input type="text" id="txtDSLichCongTacThang_ID" runat="server" />
            ds lct tuần
            <input type="text" id="txtDSLichCongTacTuan" runat="server" />
            ds lct tuần id
            <input type="text" id="txtDSLichCongTacTuan_ID" runat="server" />
            ds số người xem lct tuần
            <input type="text" id="txtDSSoNguoiXem_LCT_Tuan" runat="server" />
            ds số người nhập nxsk
            <input type="text" id="txtDSSoNguoiNhap_NXSK" runat="server" />
            <input type="text" id="txtDSThangNXSK" runat="server" />
            ds lbg
            <input type="text" id="txtDSLichBaoGiangTuan" runat="server" />
            ds số người nhập lbg
            <input type="text" id="txtDSSoNguoiDaNhap_LBG_Tuan" runat="server" />\
            tổng giáo viên
            <input type="text" id="txtTongGiaoVien" runat="server" />
            tuan id
            <input type="text" id="txtTuanID" runat="server" />
            ds hoc sinh trong lop suc khoe
        <input type="text" runat="server" id="txtDanhSachHocSinh" />
            <input type="text" runat="server" id="txtDanhSachSucKhoeHocSinhDaChon" />
            <input type="text" runat="server" id="txtDanhSachSucKhoeTenHocSinhDaChon" />
            <%--Can nang--%>
            <input type="text" runat="server" id="txtCanNangThang" />
            <%--Chieu cao--%>
            <input type="text" runat="server" id="txtChieuCaoThang" />
        </div>
    </div>


    <div style="display: none">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <input type="text" id="txtThangDuocChon" runat="server" />
                <a href="javascript:void(0)" id="btnXemChiTiet_LCT_Thang" runat="server" onserverclick="btnXemChiTiet_LCT_Thang_ServerClick">xem chi tiết</a>
                <input type="text" id="txtTuanDuocChon" runat="server" />
                <a href="javascript:void(0)" id="btnXemChiTiet_LCT_Tuan" runat="server" onserverclick="btnXemChiTiet_LCT_Tuan_ServerClick">xem chi tiết</a>
                <input type="text" id="txtTuanDuocChonBG" runat="server" />
                <a href="javascript:void(0)" id="btnXemChiTiet_LBG_Tuan" runat="server" onserverclick="btnXemChiTiet_LBG_Tuan_ServerClick"></a>
                <input type="text" id="txtThangDuocChonNXSK" runat="server" />
                <a href="javascript:void(0)" id="btnXemChiTiet_NXSK_Thang" runat="server" onserverclick="btnXemChiTiet_NXSK_Thang_ServerClick"></a>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%--modal hiện ds chi tiết người xem lịch công tác tháng--%>
    <dx:ASPxPopupControl ID="popupXemChiTiet_LCT_Thang" runat="server" Width="1000px" Height="600px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupXemChiTiet_LCT_Thang" ShowFooter="false"
        HeaderText="THỐNG KÊ CHI TIẾT XEM LỊCH CÔNG TÁC" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-5 mr-2">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên đã xem</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                    <th scope="col">Ngày xem</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpDSDaXem">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-sm-center"><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                            <td><%#Eval("xemcongtacthang_ngayxem","{0:dd/MM/yyyy}") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-5">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên chưa xem</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpDSChuaXem">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
    <%--modal hiện ds chi tiết người xem lịch tuần--%>
    <dx:ASPxPopupControl ID="popupXemLCT_Tuan" runat="server" Width="1000px" Height="600px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupXemLCT_Tuan" ShowFooter="false"
        HeaderText="THỐNG KÊ CHI TIẾT XEM LỊCH CÔNG TÁC TUẦN" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-5 mr-2">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên đã xem</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                    <th scope="col">Ngày xem</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpDSDaXemTuan">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-sm-center"><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                            <td><%#Eval("xemcongtactuan_ngayxem","{0:dd/MM/yyyy}") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-5">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên chưa xem</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpDSChuaXemTuan">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
    <%--modal hiện ds chi tiết người xem lịch báo giảng--%>
    <dx:ASPxPopupControl ID="popupXemLBG_Tuan" runat="server" Width="1000px" Height="600px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupXemLBG_Tuan" ShowFooter="false"
        HeaderText="THỐNG KÊ CHI TIẾT XEM LỊCH BÁO GIẢNG" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="upPopup1" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-5 mr-2">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên đã nhập</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                    <th scope="col">Ngày nhập</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpDSDaNhap">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-sm-center"><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                            <td><%#Eval("ngaynhap","{0:dd/MM/yyyy}") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-5">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên chưa nhập</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpDSChuaNhap">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
    <%--modal hiện ds chi tiết người nhận xét sức khỏe--%>
    <dx:ASPxPopupControl ID="popupXemNXSK" runat="server" Width="1000px" Height="600px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupXemNXSK" ShowFooter="false"
        HeaderText="THỐNG KÊ CHI TIẾT NHẬN XÉT SỨC KHỎE" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-5 mr-2">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên đã nhập</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                    <th scope="col">Ngày nhập</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpNXSKDaNhap">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="text-sm-center"><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                            <td><%#Eval("ngaynhap","{0:dd/MM/yyyy}") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-5">
                                        <div class="form-group table-responsive">
                                            <h3>Danh sách giáo viên chưa nhập</h3>
                                            <table class="table table-striped table-hover">
                                                <tr style="text-align: center">
                                                    <th scope="col">#</th>
                                                    <th scope="col">Họ và tên</th>
                                                    <th scope="col">Bộ phận</th>
                                                </tr>
                                                <asp:Repeater runat="server" ID="rpNXSKChuaNhap">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td><%#Container.ItemIndex+1 %></td>
                                                            <td><%#Eval("username_fullname") %></td>
                                                            <td><%#Eval("bophan_name") %></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.5.0/Chart.min.js"></script>
    <%--<script src="js/chart.js"></script>--%>
    <script
        src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js">
    </script>
    <%--script vẽ biểu đồ--%>
    <script>

        //func vẽ biểu đồ lịch công tác tuần
        //var xValues = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12];
        var arrTuan = document.getElementById("<%=txtDSLichCongTacTuan.ClientID%>").value.split(",");
        var arrNameTuan = document.getElementById("<%=txtDSLichCongTacTuan.ClientID%>").value.split(",");
        var arrTuan_ID = document.getElementById("<%=txtDSLichCongTacTuan_ID.ClientID%>").value.split(",");
        var arrSoNguoiXem_LCT_Tuan = document.getElementById("<%=txtDSSoNguoiXem_LCT_Tuan.ClientID%>").value.split(",");
        var myCharttuan = new Chart("myCharttuan", {
            type: "bar",
            data: {
                labels: arrTuan,
                datasets: [{
                    data: arrSoNguoiXem_LCT_Tuan,
                    label: ["Đã xem"],
                    backgroundColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)',

                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)',

                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                    ],
                }]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: "Lịch công tác tuần"
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0, // minimum value
                            max: parseInt(document.getElementById("<%=txtTongGiaoVien.ClientID%>").value),
                        }
                    }]
                },
                onClick: function (e) {
                    var activePoints = myCharttuan.getElementsAtEvent(e);
                    var selectedIndex = activePoints[0]._index;
                    var tuan = this.data.labels[selectedIndex];
                    //console.log(arrTuan_ID[selectedIndex])
                    document.getElementById("<%=txtTuanDuocChon.ClientID%>").value = arrTuan_ID[selectedIndex];
                    document.getElementById("<%=btnXemChiTiet_LCT_Tuan.ClientID%>").click();
                }
            }
        });
        //func vẽ biểu đồ lịch công tác tháng
        var arrThang = document.getElementById("<%=txtDSLichCongTacThang.ClientID%>").value.split(",");
        var arrThang_ID = document.getElementById("<%=txtDSLichCongTacThang_ID.ClientID%>").value.split(",");
        var arrSoNguoi = document.getElementById("<%=txtDSSoNguoiXem_LCT_Thang.ClientID%>").value.split(",");
        var myChartthang = new Chart("myChartthang", {
            type: "bar",
            data: {
                labels: arrThang,
                datasets: [{
                    label: ["Đã xem"],
                    data: arrSoNguoi,
                    backgroundColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)'
                    ],
                }]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: "Lịch công tác tháng"
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0, // minimum value
                            max: parseInt(document.getElementById("<%=txtTongGiaoVien.ClientID%>").value),
                        }
                    }]
                },
                onClick: function (e) {
                    var activePoints = myChartthang.getElementsAtEvent(e);
                    var selectedIndex = activePoints[0]._index;
                    var thang = arrThang_ID[selectedIndex];
                    //console.log(thang);
                    document.getElementById("<%=txtThangDuocChon.ClientID%>").value = thang;
                    document.getElementById("<%=btnXemChiTiet_LCT_Thang.ClientID%>").click();
                }
            }
        });
        //func vẽ biểu đồ nhận xét
        var arrSoNguoiDaNhap_NXSK = document.getElementById("<%=txtDSThangNXSK.ClientID%>").value.split(",");
        var arr = ["", "", "", "", "", "", "", "", "", ""];
        for (var i = 0; i < arrSoNguoiDaNhap_NXSK.length; i++) {
            var arr_value = arrSoNguoiDaNhap_NXSK[i].split("|");
            for (var j = 0; j < arrThang.length; j++) {
                if (arr_value[0] == arrThang[j]) {
                    arr[j] = arr_value[1]
                }
            }
        }
        var barColors = ["red", "green", "blue", "orange", "brown", "purple", "blue", "green", "black", "brown"];
        var myChartnhanxet = new Chart("myChartnhanxet", {
            type: "bar",
            data: {
                labels: arrThang,
                datasets: [{
                    label: ["Giáo viên đã nhập"],
                    data: arr,
                    backgroundColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)'
                    ],
                }]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: "Nhận xét sức khỏe"
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0, // minimum value
                            max: parseInt(document.getElementById("<%=txtTongGiaoVien.ClientID%>").value), // maximum value
                        }
                    }]
                },
                onClick: function (e) {
                    var activePoints = myChartnhanxet.getElementsAtEvent(e);
                    var selectedIndex = activePoints[0]._index;
                    var tuan = this.data.labels[selectedIndex];
                    //console.log(tuan)
                    document.getElementById("<%=txtThangDuocChonNXSK.ClientID%>").value = tuan;
                    document.getElementById("<%=btnXemChiTiet_NXSK_Thang.ClientID%>").click();
                }

            }
        });
        //debugger;
        //func vẽ biểu đồ báo giảng theo tuần
        var arrTuanLBG = document.getElementById("<%=txtDSLichBaoGiangTuan.ClientID%>").value.split(",");
        var arrSoNguoiDaNhap_LBG_Tuan = document.getElementById("<%=txtDSSoNguoiDaNhap_LBG_Tuan.ClientID%>").value.split(",");
            //var arrTuanLBGLists = document.getElementById("<%=txtDSLichCongTacTuan.ClientID%>").value.split(",");

        var arrIDTuan = document.getElementById("<%=txtTuanID.ClientID%>").value.split(",");
        var arrDSLBG = arrTuan;
        for (var i = 0; i < arrTuanLBG.length; i++) {
            var arr_value = arrTuanLBG[i].split("|"); //sl gv|tuan
            //console.log(arr_value)
            //console.log(arrTuan)
            for (var j = 0; j < arrTuan.length; j++) {
                if (arr_value[1].trim() == arrTuan[j].trim()) {
                    //console.log(arr_value[1])
                    arrDSLBG[j] = arr_value[0]
                }
            }
        }

        var myChartbaogiang = new Chart("myChartbaogiang", {
            type: "bar",
            data: {
                labels: arrNameTuan,
                datasets: [{
                    label: ['Đã nhập'],
                    data: arrDSLBG,//arrSoNguoiDaNhap_LBG_Tuan,
                    //borderColor: "blue"
                    //fill: false
                    backgroundColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)',
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)',
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                        'rgba(13, 170, 104, 1)',
                        'rgba(46, 100, 130, 1)',
                        'rgba(199, 90, 86, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 150, 113, 1)',
                        'rgba(255, 110, 110, 1)',
                        'rgba(240, 170, 100, 1)',
                        'rgba(255, 192, 112, 1)',
                    ],
                }]
            },
            options: {
                legend: { display: false },
                title: {
                    display: true,
                    text: "Lịch báo giảng tuần"
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            min: 0, // minimum value
                            max: parseInt(document.getElementById("<%=txtTongGiaoVien.ClientID%>").value),
                        }
                    }]
                },
                onClick: function (e) {
                    var activePoints = myChartbaogiang.getElementsAtEvent(e);
                    var selectedIndex = activePoints[0]._index;
                    var tuan = arrIDTuan[selectedIndex];
                    console.log(tuan)
                    document.getElementById("<%=txtTuanDuocChonBG.ClientID%>").value = tuan;
                    document.getElementById("<%=btnXemChiTiet_LBG_Tuan.ClientID%>").click();
                }
            }
        });
        //Thong ke suc khoe theo chieu cao va can nang

        var color = ['rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 150, 113, 1)',
            'rgba(255, 110, 110, 1)',
            'rgba(240, 170, 100, 1)',
            'rgba(255, 192, 112, 1)',
            'rgba(13, 170, 104, 1)',
            'rgba(46, 100, 130, 1)',
            'rgba(199, 90, 86, 1)',
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 150, 113, 1)',
            'rgba(255, 110, 110, 1)',
            'rgba(240, 170, 100, 1)',
            'rgba(255, 192, 112, 1)',
            'rgba(13, 170, 104, 1)',
            'rgba(46, 100, 130, 1)',
            'rgba(199, 90, 86, 1)',
            'rgba(255, 99, 132, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 150, 113, 1)',
            'rgba(255, 110, 110, 1)',
            'rgba(240, 170, 100, 1)',
            'rgba(255, 192, 112, 1)',
            'rgba(13, 170, 104, 1)',
            'rgba(46, 100, 130, 1)',
            'rgba(199, 90, 86, 1)',
            'rgba(255, 150, 113, 1)',
            'rgba(255, 110, 110, 1)',
            'rgba(54, 162, 235, 1)',
            'rgba(255, 206, 86, 1)',
            'rgba(75, 192, 192, 1)',
            'rgba(153, 102, 255, 1)',
            'rgba(255, 150, 113, 1)',
            'rgba(255, 110, 110, 1)',
            'rgba(240, 170, 100, 1)',
            'rgba(255, 192, 112, 1)',]

        function btnDanhSachHocSinh() {
            var arrDSHSDC = []
            var arrIDHS = document.getElementById("<%=txtDanhSachHocSinh.ClientID%>").value.split(',')
            for (var i = 0; i < arrIDHS.length; i++) {
                var elementsCheck = $('#hsId_' + arrIDHS[i])
                if (elementsCheck.is(":checked")) {
                    arrDSHSDC.push(elementsCheck.val())
                }
            }
            document.getElementById("<%=txtDanhSachSucKhoeHocSinhDaChon.ClientID%>").value = arrDSHSDC
            document.getElementById("<%=btnShowSucKhoe.ClientID%>").click()
        }
        var arrDanhSachHocSinh = document.getElementById("<%=txtDanhSachSucKhoeTenHocSinhDaChon.ClientID%>").value.split(",")

        //Can nang
        var weightThang = document.getElementById("<%=txtCanNangThang.ClientID%>").value.split(",")
        var arrSucKhoeCanNang = document.getElementById("<%=txtDanhSachSucKhoeHocSinhDaChon.ClientID%>").value.split(",")

        var arrSucKhoe = [[], [], [], [], [], [], [],
        [], [], [], [], [], [], [], [], [], [], [], [], [], [],
        [], [], [], [], [], [], [], [], [], [], [], [], [], [],
        [], [], [], [], [], [], [], [], [], [], [], [], [], [],
        [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], [], []]

        for (var i = 0; i < weightThang.length; i++) {
            var arr_value = weightThang[i].split("|");
            for (var z = 0; z < arrSucKhoeCanNang.length; z++) {
                if (arr_value[1] == arrSucKhoeCanNang[z]) {
                    arrSucKhoe[z].push(arr_value[0])
                } else {
                    arrSucKhoe[z].push("")
                }
            }
            console.log(arr_value)
        }

        const ctx = document.getElementById('myChartSucKhoeCanNang');

        const myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: ['Tháng 1', 'Tháng 2', 'Tháng 3', 'Tháng 4', 'Tháng 5', 'Tháng 6',
                    'Tháng 7', 'Tháng 8', 'Tháng 9', 'Tháng 10', 'Tháng 11', 'Tháng 12'],
                datasets: arrDanhSachHocSinh.map((ds, i) => ({
                    label: arrDanhSachHocSinh[i],
                    data: arrSucKhoe[i],
                    fill: false,
                    borderColor: color[i],
                    borderWidth: 1,
                }))
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true,
                        min: 0,
                    }
                }
            }
        });
        //chieuCao
        var heightThang1 = document.getElementById("<%=txtChieuCaoThang.ClientID%>").value.split(",")

        const ctx2 = document.getElementById('myChartSucKhoeChieuCao');

    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>
