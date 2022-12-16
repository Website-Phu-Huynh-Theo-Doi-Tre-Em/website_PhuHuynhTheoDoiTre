<%@ Page Title="" Language="C#" MasterPageFile="~/Website_MasterPage.master" AutoEventWireup="true" CodeFile="web_XinNghi.aspx.cs" Inherits="web_module_module_website_website_VietNhatKis_web_XinNghi" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/Web_ThanhChucnang.ascx" TagPrefix="uc1" TagName="Web_ThanhChucnang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="../../admin_js/sweetalert.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="../../../assets/css/Calender.css" rel="stylesheet" />
    <script src="../../admin_js/sweetalert.min.js"></script>
    <script src="https://cpwebassets.codepen.io/assets/common/stopExecutionOnTimeout-1b93190375e9ccc259df3a57c1abc0e64599724ae30d7ea4c6877eb615f89387.js"></script>
    <link href="../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        body {
            background-color: #e7e7e8;
        }

        .container_left {
            /*            background-color: #ffffff;*/
            border-radius: 10px;
            margin: 0.75% 0;
            display: flex;
            height: 32rem;
        }



        .container_right {
            background-color: #ffffff;
            border-radius: 10px;
            overflow: auto;
            margin-left: 0;
            max-height: 32rem;
            height: 100%;
            padding: 2%;
            overflow-x: hidden;
        }

        .table {
            width: 100%;
            max-width: 100%;
            background-color: transparent;
            text-align: center;
            overflow-y: scroll;
            height: 50%;
        }

        .block_Title {
            font-size: 18px;
            text-align: center;
            color: #a10101;
        }

        select {
            background-color: #ffffff;
            border: none;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
        }

        /*thead {
            background-color: #f7e8e3;
            border: 2px solid #f1ae98;
        }*/

        tr {
            border-bottom: 1.5px solid #f1ae98;
        }

        /*.row {
            padding: 0 !important;
            margin-right: -87px;
        }*/

        .table {
            width: 100%;
            max-width: 100%;
            background-color: transparent;
            text-align: center;
            overflow-y: scroll;
            height: 50%;
        }

            .table td, .table th {
                padding: 10px;
                vertical-align: top;
                border-top: 1px solid #940808;
            }

            .table th {
                text-align: inherit;
                border: 1px solid white;
                padding: 1%;
                color: white;
                background: #a10101;
                font-weight: 500;
                font-size: 12px;
            }

        .box__modal .table {
            width: 100%;
            text-align: center;
        }

        h4 {
            margin-bottom: 0;
            text-align: center;
            color: #940808;
            font-size: 18px;
            font-weight: bold;
        }

        input {
            width: 70%;
            height: 40px;
            padding: 2px 8px;
            border-radius: 8px;
            outline: none;
            border: 1px solid #333;
        }

        .flex-between {
            margin-bottom: 2%;
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: space-between;
        }

        .blockMain {
            text-align: center;
            background-color: white;
            border-radius: 10px;
            box-shadow: 3px 2px 18px #99999942;
            height: 100%;
            display: flex;
            flex-direction: column;
            flex-wrap: nowrap;
            justify-content: center;
        }

        .col-5 {
            padding: 0
        }

        .container_left_bottom {
            background-color: #ffffff;
            border-radius: 10px;
            padding: 2%;
            display: flex;
            flex-direction: column;
            width: 60%;
            justify-content: center;
        }

        * {
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }

        h6 {
            font-size: 14px;
        }

        .table tr {
            font-size: 14px;
            padding: 1% 0.5%;
        }

        .container-calendar th {
            text-align: inherit;
            border: 1px solid white;
            padding: 1%;
            color: white;
            background: #a10101;
            font-size: 10px;
            font-weight: 500;
        }

        .container_left_top {
            width: 50%;
        }

        .date-picker.selected {
            font-weight: bold;
            outline: 2px dashed #00BCD4;
            color: red;
        }

        .date-picker:nth-child(1) {
            color: black;
        }

        .ngay_nghihoc {
            background: #bd3232;
            color: #fff;
        }

        @media (min-width: 500px) and (max-width:1050px) {
            .row {
                margin: 0% 0% 1% 0 !important;
            }
            /*.userrp{
                margin:1% 0;
            }*/
            .colrp {
                padding-left: 0 !important;
                padding-right: 0;
            }

            .container_right {
                margin-top: 2%
            }
        }

        .row {
            margin: 0;
            padding: 0 !important
        }

        .fas.fa-check-circle {
            color: forestgreen;
        }

        .fas.fa-exclamation-circle {
            color: red;
        }
    </style>
    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid row">
        <div class="col-xl-3 col-md-12 float-left">
            <uc1:Web_ThongTinCaNhan runat="server" ID="Web_ThongTinCaNhan" />
        </div>
        <%-- <div class="col-xl-9 col-md-12 float-right" style="padding: 0">--%>
        <div class="col-xl-9 col-md-12">
            <div class="col-xl-12 col-md-12 userrp" style="padding: 0">
                                <uc1:Web_ThanhChucnang runat="server" ID="Web_ThanhChucnang" />

            </div>
            <div class="loading" id="img-loading-icon" style="display: none">
                <div class="loading">Loading&#8230;</div>
            </div>
            <div class="col-12 row " style="padding: 0; margin: 0">
                <div class="container_left col-xl-7 col-md-12 colrp" style="margin: 0; padding-left: 0">
                    <div class="container_left_top" style="margin-right: 2.5%; padding-left: 0">
                        <div id="block_DiemDanh" class="blockMain">
                            <div id="block_ContentDiemDanh">
                                <div>
                                    <div id="block_TitleDiemDanh" class="block_Title" style="font-size: 18px; font-weight: bold; text-transform: uppercase">Nhật kí điểm danh</div>
                                    <div class="container-calendar">
                                        <div class="button-container-calendar" style="display: flex; justify-content: space-between; align-items: center">
                                            <a href="javascript:void(0)" class="calendar_button" id="previous" onclick="previous()">&#8249;</a>
                                            <p id="monthAndYear" class="m-0"></p>
                                            <a href="javascript:void(0)" class="calendar_button" id="next" onclick="next()">&#8250;</a>
                                        </div>
                                        <table class="table-calendar" id="calendar" data-lang="en">
                                            <thead id="thead-month"></thead>
                                            <tbody id="calendar-body"></tbody>
                                        </table>
                                        <div class="footer-container-calendar" style="display: none;">
                                            <label for="month">Jump To: </label>
                                            <select id="month" runat="server" onchange="jump()">
                                                <option value="0">Jan</option>
                                                <option value="1">Feb</option>
                                                <option value="2">Mar</option>
                                                <option value="3">Apr</option>
                                                <option value="4">May</option>
                                                <option value="5">Jun</option>
                                                <option value="6">Jul</option>
                                                <option value="7">Aug</option>
                                                <option value="8">Sep</option>
                                                <option value="9">Oct</option>
                                                <option value="10">Nov</option>
                                                <option value="11">Dec</option>
                                            </select>
                                            <select id="year" runat="server" onchange="jump()"></select>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <input type="text" id="txtSoNgayNghi" runat="server" hidden="hidden" />
                    <input type="text" id="txtNgayBatDau" runat="server" hidden="hidden" />
                    <input type="text" id="txtNgayKetThuc" runat="server" hidden="hidden" />
                    <input type="text" id="txtDanhSachNgayNghi" runat="server" hidden="hidden" />
                    <div class="container_left_bottom" style="box-shadow: 2px 3px 8px 5px #80808029;">
                        <div>
                            <h4 style="padding-bottom: 20px; text-transform: uppercase">Đơn xin nghỉ</h4>
                        </div>
                        <div id="block_Content">
                            <div class="flex-between position-relative" style="margin-bottom: 2% 0">
                                <h6>Từ ngày:</h6>
                                <input type="date" id="dteTuNgay" runat="server" class="inputBlock date">
                            </div>
                            <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                <h6>Đến ngày:</h6>
                                <input type="date" id="dteDenNgay" runat="server" class="inputBlock">
                            </div>
                            <div class="flex-between" style="margin-bottom: 2% 0">
                                <textarea id="txtDanDo" runat="server" class="inputBlock" style="height: 100%; border-radius: 8px; padding: 1%; width: 100%;" placeholder="Lý do..." rows="4"></textarea>
                            </div>
                            <div class="col-auto" style="display: flex; flex-direction: row-reverse; padding-right: 0; margin-top: 5%;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <a href="#" id="btnGui" onclick="return checkNULL()" runat="server" onserverclick="btnGui_Click" style="display: block; background: #a10101; line-height: 1; border: none" class="btn  btn-success ">Xin phép nghỉ</a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="col-xl-5 col-md-12" style="padding-right: 0; padding-left: 0">
                    <div class="container_right" style="box-shadow: 2px 3px 8px 5px #80808029;">
                        <div>
                            <h4 style="font-size: 20px; margin-bottom: 2%; font-weight: bold; color: #1f58c1; text-transform: uppercase /* color: aqua; */">Lịch sử xin nghỉ năm 
                                <asp:Label ID="lblNam" runat="server"></asp:Label></h4>
                        </div>
                        <div>
                            <%--<div style="width: 100%; margin: 2% 0;">
                                <asp:DropDownList ID="ddlNam" runat="server" OnSelectedIndexChanged="ddlNam_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>--%>
                            <div>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Ngày đăng kí</th>
                                            <th scope="col">Ngày bắt đầu</th>
                                            <th scope="col">Ngày kết thúc</th>
                                            <th scope="col">Xác nhận</th>
                                            <th scope="col">Nội dung</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="rpXinNghi" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td scope="row"><%= STT++ %></td>
                                                    <td><%#Eval("phuhuynhxinnghi_ngaydangki","{0:dd/MM/yyyy}") %></td>
                                                    <td><%#Eval("phuhuynhxinnghi_ngaybatdau","{0:dd/MM/yyyy}")%></td>
                                                    <td><%#Eval("phuhuynhxinnghi_ngayketthuc","{0:dd/MM/yyyy}") %></td>

                                                    <td><%#Eval("tinhtrang") %></td>
                                                    <td>
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                 <button style="display: inline-block; background-color: unset !important; border: unset !important; padding: 0; font-weight: 700; color: #28a745 !important;"
                                                            class="btn btn-success" data-toggle="modal" data-target="#myModal_<%#Eval ("phuhuynhxinnghi_id") %>">
                                                            Chi tiết
                                                        </button>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                       
                                                    </td>
                                                    <%--<td><%#Eval("phuhuynhxinnghi_content") %></td>--%>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                                <%-- my_model --%>
                                <asp:Repeater ID="rpChiTietXinNghi" runat="server">
                                    <ItemTemplate>
                                        <div class="modal fade" id="myModal_<%#Eval("phuhuynhxinnghi_id") %>" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                                            <div class="modal-dialog modal-dialog-centered">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h4 class="modal-title">Chi tiết xin nghỉ</h4>
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="flex-between" style="margin-bottom: 20px;">
                                                            <h6 style="margin-bottom: 0; text-align: left;">Ngày đăng kí</h6>
                                                            <input type="text" readonly="readonly" id="txtTenBenh_<%#Eval("phuhuynhxinnghi_id") %>" class="inputBlock" value="<%#Eval("phuhuynhxinnghi_ngaydangki","{0:dd/MM/yyyy}") %>" />
                                                        </div>
                                                        <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                                            <h6 style="margin-bottom: 0; text-align: left;">Từ ngày:</h6>
                                                            <input type="date" readonly="readonly" id="txtTuNgay_<%#Eval("phuhuynhxinnghi_id") %>" value="<%# Eval("phuhuynhxinnghi_ngaybatdau", "{0:yyyy-MM-dd}")%>" class="inputBlock">
                                                        </div>
                                                        <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                                            <h6 style="margin-bottom: 0; text-align: left;">Đến ngày:</h6>
                                                            <input type="date" readonly="readonly" id="txtDenNgay_<%#Eval("phuhuynhxinnghi_id") %>" value="<%#Eval("phuhuynhxinnghi_ngayketthuc", "{0:yyyy-MM-dd}") %>" class="inputBlock">
                                                        </div>

                                                        <div class="flex-between" style="margin-bottom: 20px;">
                                                            <textarea readonly="readonly" class="inputBlock" id="txtNoiDungDanDo_<%#Eval("phuhuynhxinnghi_id") %>" style="height: 100%; width: 100%; padding: 2%; }"
                                                                placeholder="Dặn dò..." rows="4"><%#Eval("phuhuynhxinnghi_lydo") %></textarea>
                                                        </div>
                                                    </div>
                                                    <%--<div class="modal-footer">
                                                        <a href="javascript:void(0)" onclick="myCapNhat('<%#Eval("phuhuynhxinnghi_id") %>')" class="btn btn-danger">Gửi</a>
                                                    </div>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%--  --%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/flatpickr/4.2.3/flatpickr.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/moment-with-locales.min.js"></script>
    <script>
        //func kiểm tra dữ liệu rỗng trước khi submit
        function checkNULL() {
            var tuNgay = document.getElementById('<%= dteTuNgay.ClientID%>');
            var denNgay = document.getElementById('<%= dteDenNgay.ClientID%>');
            var denNgay = document.getElementById('<%= txtDanDo.ClientID%>');
            if (tuNgay.value.trim() == "" || denNgay.value.trim() == "") {
                swal('Vui lòng nhập đầy đủ thông tin xin nghỉ!', '', 'warning');
                return false;
            }
            DisplayLoadingIcon();
            return true;
        }

    </script>
    <script>
        $(function () {
            var dtToday = new Date();

            var month = dtToday.getMonth() + 1;
            var day = dtToday.getDate();
            var year = dtToday.getFullYear();
            if (month < 10)
                month = '0' + month.toString();
            if (day < 10)
                day = '0' + day.toString();

            var maxDate = year + '-' + month + '-' + day;

            $('#ContentPlaceHolder1_dteTuNgay').attr('min', maxDate);
            $('#ContentPlaceHolder1_dteDenNgay').attr('min', maxDate);
        });
    </script>
    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
    </script>
    <script>

        $(function () {
            var dtToday = new Date();

            var month = dtToday.getMonth() + 1;
            var day = dtToday.getDate();
            var year = dtToday.getFullYear();
            if (month < 10)
                month = '0' + month.toString();
            if (day < 10)
                day = '0' + day.toString();

            var maxDate = year + '-' + month + '-' + day;

            $('#ContentPlaceHolder1_dteTuNgay').attr('min', maxDate);
            $('#ContentPlaceHolder1_dteDenNgay').attr('min', maxDate);
        });

        function generate_year_range(start, end) {
            var years = "";
            for (var year = start; year <= end; year++) {
                years += "<option value='" + year + "'>" + year + "</option>";
            }
            return years;
        }

        var today = new Date();
        var currentMonth = today.getMonth();
        var currentYear = today.getFullYear();

        var selectYear = document.getElementById("<%=year.ClientID%>");

        var selectMonth = document.getElementById("<%=month.ClientID%>");

        var createYear = generate_year_range(2022, 2050);

        document.getElementById("<%=year.ClientID%>").innerHTML = createYear;

        var calendar = document.getElementById("calendar");
        var lang = calendar.getAttribute('data-lang');

        var months = ["Tháng 01", "Tháng 02", "Tháng 03", "Tháng 04", "Tháng 05", "Tháng 06", "Tháng 07", "Tháng 08", "Tháng 09", "Tháng 10", "Tháng 11", "Tháng 12"];
        var days = ["CN", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7"];

        var dayNghi = ["CN", "Thứ 7"];

        var dayHeader = "<tr>";

        for (day in days) {
            dayHeader += "<th data-days='" + days[day] + "' class='date_header'>" + days[day] + "</th>";
        }

        dayHeader += "</tr>";

        document.getElementById("thead-month").innerHTML = dayHeader;

        monthAndYear = document.getElementById("monthAndYear");
        showCalendar(currentMonth, currentYear);

        function jump() {
            currentYear = parseInt(selectYear.value);
            currentMonth = parseInt(selectMonth.value);
            showCalendar(currentMonth, currentYear);
        }

        //func prev month 
        function previous() {
            let currentMonth = parseInt(selectMonth.value);
            selectMonth.value = currentMonth - 1;
            selectMonth.onchange();
        }
        //func prev next 
        function next() {
            let currentMonth = parseInt(selectMonth.value);
            selectMonth.value = currentMonth + 1;
            selectMonth.onchange();
        }
        function showCalendar(month, year) {
            var soNgayNghi = parseInt(document.getElementById("<%=txtSoNgayNghi.ClientID%>").value);

            var ngayBatDau = document.getElementById("<%=txtNgayBatDau.ClientID%>").value.split(';');
            var ngayKetThuc = document.getElementById("<%=txtNgayKetThuc.ClientID%>").value.split(';');

            var arr_ngayNghi = [];
            var arr_thangNghi = [];
            console.log(ngayBatDau, ngayKetThuc)

            Date.prototype.addDays = function (days) {
                const date = new Date(this.valueOf());
                date.setDate(date.getDate() + days);
                return date;
            };

            for (var i = 0; i < ngayBatDau.length; i++) {
                //debugger;
                var middle
                var future = moment(ngayKetThuc[i]);
                var start = moment(ngayBatDau[i]);
                var d = parseInt(future.diff(start, 'days') + 1);//số lượng ngày nghỉ
                console.log("So luogn ngay nghi :" + d);
                var ngayNghiBatDau = new Date(ngayBatDau[i]);

                for (var j = 1; j <= d; j++) {
                    if (j == 1) {
                        arr_ngayNghi.push(ngayNghiBatDau.getDate().toString())
                        parseInt(arr_thangNghi.push(ngayNghiBatDau.getMonth() + 1));
                    } else {
                        arr_ngayNghi.push(middle.getDate().toString())
                        parseInt(arr_thangNghi.push(middle.getMonth() + 1));
                    }
                    middle = ngayNghiBatDau.addDays(j)
                }
            }

            console.log("arr_ngayNghi, arr_thangNghi, soNgayNghi:" + arr_ngayNghi, arr_thangNghi, soNgayNghi)

            var firstDay = (new Date(year, month)).getDay();
            tbl = document.getElementById("calendar-body");
            tbl.innerHTML = "";

            monthAndYear.innerHTML = months[month] + " " + year;
            selectYear.value = year;
            selectMonth.value = month;

            // creating all cells
            var date = 1;
            for (var i = 0; i < 6; i++) {
                var row = document.createElement("tr");

                for (var j = 0; j < days.length; j++) {
                    if (i === 0 && j < firstDay) {
                        cell = document.createElement("td");
                        cellText = document.createTextNode("");
                        cell.appendChild(cellText);
                        row.appendChild(cell);
                    } else if (date > daysInMonth(month, year)) {
                        break;
                    } else {
                        cell = document.createElement("td");
                        cell.setAttribute("data-date", date);
                        cell.setAttribute("data-month", month + 1);
                        cell.setAttribute("data-year", year);
                        cell.setAttribute("data-month_name", months[month]);
                        cell.className = "date-picker";
                        cell.innerHTML = "<span>" + date + "</span>";

                        if (date === today.getDate() && year === today.getFullYear() && month === today.getMonth()) {
                            cell.className = "date-picker selected";
                        }

                        for (var x = 0; x < arr_ngayNghi.length; x++)
                            if (arr_thangNghi[x] == currentMonth + 1)
                                if (arr_ngayNghi[x] == cell.getAttribute("data-date"))
                                    cell.setAttribute("class", "ngay_nghihoc")
                        row.appendChild(cell);
                        date++;
                    }
                }
                tbl.appendChild(row);
            }
            //console.log("arr_ngayNghi, arr_thangNghi:"+arr_ngayNghi, arr_thangNghi)
        }

        function daysInMonth(iMonth, iYear) {
            return 32 - new Date(iYear, iMonth, 32).getDate();
        }

    </script>

</asp:Content>

