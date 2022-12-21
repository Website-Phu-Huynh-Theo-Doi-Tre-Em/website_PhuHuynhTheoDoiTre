<%@ Page Title="" Language="C#" MasterPageFile="~/Website_MasterPage.master" AutoEventWireup="true" CodeFile="Web_DangKyAnSang.aspx.cs" Inherits="web_module_website_VietNhatKids_Web_DangKyAnSang" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/Web_ThanhChucnang.ascx" TagPrefix="uc1" TagName="Web_ThanhChucnang" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="../../admin_js/sweetalert.min.js"></script>
    <style>
        .container-left .container-content {
            display: flex;
            flex-direction: column;
            flex-wrap: wrap;
            align-content: center;
            justify-content: center;
            align-items: center;
        }

        .container-left-img {
            position: relative;
            background-color: #E5E6F3;
            display: flex;
            flex-direction: row;
            flex-wrap: nowrap;
            align-content: center;
            justify-content: space-between;
            align-items: center;
            padding: 5%;
            border-radius: 6px;
        }

            .container-left-img .left-img {
                width: 32%;
                height: 91%;
                background-color: white;
                box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);
            }

            .container-left-img input {
                position: absolute;
            }

            .container-left-img p {
                font-weight: 400;
                text-align: center;
            }

        button {
            background-color: #BD3232;
            border-radius: 6px;
            border: none;
            color: #FFFFFF;
            padding: 3px;
            box-shadow: 0px 2px 1px 1px rgb(0 0 0 / 25%);
            margin: 0 1%;
        }

        .container-right {
            padding: 2%;
            background: white;
            height: 32rem;
            border-radius: 10px;
        }

        .container-right-title {
            font-weight: 700;
            font-size: 19px;
            color: #C90000;
            text-align: center;
        }

        .container-right table, th, td {
            font-size: 14px;
            border: 1px solid #a3a0a0;
        }

        table tr th {
            font-size: 14px;
            text-align: center;
            color: white;
            background: #BD3232;
            padding: 0.5%;
        }

        /*  .txt {
            text-align: unset;
            padding-left: 1%;
        }*/

        table tr td {
            text-align: center;
            font-weight: 500;
        }

        .nd {
            font-size: 15px;
            width: 5%;
        }



        .container-left .btn-button {
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            align-content: center;
            justify-content: flex-start;
            align-items: center;
            margin: 1% 0;
        }

        .pp {
            display: block;
            background-color: white;
            color: blue;
            border: none;
        }

        * {
            margin: 0;
            padding: 0;
        }

        body {
            background-color: #e7e7e8;
        }

        .container_left {
            border-radius: 10px;
            margin: 1% 0;
            display: flex;
            flex-direction: column;
            justify-content: space-evenly;
        }



        .container_right {
            background-color: #ffffff;
            border-radius: 10px;
            padding: 1%;
            overflow: auto;
            margin: 1% 0;
            margin-left: 0;
            max-height: 32rem;
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

        thead {
            background-color: #f7e8e3;
            border: 2px solid #f1ae98;
        }

        tr {
            border-bottom: 1.5px solid #f1ae98;
        }

        .row {
            padding: 0 !important;
            /* height: 600px;*/
            margin-right: -87px;
        }

        .table {
            width: 100%;
            max-width: 100%;
            background-color: transparent;
            text-align: center;
            overflow-y: scroll;
            height: 50%;
        }

            .table td, .table th {
                padding: 0.5rem;
                vertical-align: top;
                border-top: 1px solid #940808;
                /*padding: 5px;*/
            }

            .table th {
                text-align: inherit;
                border: 1px solid white;
                padding: 1%;
                color: white;
                background: #a10101;
                font-weight: 500;
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
            width: 4%;
            height: 48px;
            padding: 8px;
            border-radius: 8px;
            outline: none;
            border: 1px solid #333;
        }

        .flex-between {
            margin-bottom: 20px;
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: space-between;
        }

        .block-bieudo {
            background-color: #ffffff;
            width: 100%;
            height: 32rem;
            border-radius: 10px;
            padding: 0 4%;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
        }

        .table thead th {
            vertical-align: bottom;
            border-bottom: 2px solid #dee2e6;
            padding: 5px;
        }

        .btn-success {
            border: none !important;
        }

        .btn.btn-success {
            box-shadow: none !important;
        }

        button {
            box-shadow: none !important;
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

        .block-bieudo {
            background-color: #ffffff;
            width: 100%;
            height: 32rem;
            border-radius: 10px;
            padding: 0 4%;
            display: flex;
            flex-direction: column;
            justify-content: flex-start;
        }
    </style>
    <script>
        function myCheck(tinhtrang) {
            document.getElementById('<%=txtTinhTrang.ClientID%>').value = tinhtrang;

        }

        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }

        function btnShow() {
            document.getElementById("<%=btnHuyDangKy.ClientID%>").style.display = 'block';
            document.getElementById("<%=btnDangKy.ClientID%>").style.display = 'none';

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
            <div class="col-12 row" style="padding: 0">
                <div class="container_left col-5" style="padding-left: 0">

                    <div class="block-bieudo" style="box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);">

                        <div id="block_Content">
                            <div style="display: flex; flex-direction: column; align-items: center;">
                                <img style="max-width: 50% !important; min-width: 50%;"
                                    src="../../image_/Logo.png" />
                            </div>
                            <div>
                                <h4 style="padding-bottom: 20px; color: #C90000;">ĐĂNG KÍ ĂN SÁNG, UỐNG SỮA</h4>
                            </div>
                            <div class="container-content">
                                <p class="container-left-sec" style="font-size: 15px;">
                                    <span class="left-star" style="color: red">*</span>
                                    Phụ huynh đăng kí ăn sáng/uống sữa là đăng kí vào cuối tháng và học phí ăn sáng sẽ được tính vào tháng tiếp theo.
                                </p>
                                <p class="container-left-sec" style="font-size: 15px;">
                                    <span class="left-star" style="color: red">*</span>
                                    Phụ huynh hủy đăng kí ăn sáng/uống sữa là đăng ký vào cuối tháng. Học phí ăn sáng vẫn được tính đến hết tháng hiện tại và sẽ không tính học phí ăn sáng vào tháng tiếp theo.
                                </p>
                            </div>
                            <%--<div class="container-left-img">
                                <div class="left-img">
                                    <input type="radio" id="ansang" value="an" onclick="myCheck(this.value)" name="choose" style="top: 9%; left: 18%;" />
                                   
                                    <label for="ansang">
                                        <img style="padding: 15% 15% 0 15%;" src="/images/an.png" />
                                        <p style="font-size: 14px; font-weight: 600; top: -5%; position: relative;">
                                            Ăn sáng
                                        </p>

                                    </label>
                                </div>
                                <div class="left-img-1" style="width: 30%; height: 91%; background-color: white; box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);">
                                    <input type="radio" id="uongsua" value="uong" onclick="myCheck(this.value)" name="choose" style="left: 49%; top: 9%;" />
                                   
                                    <label style="font-size: 14px; font-weight: 600; top: -4%; position: relative;" for="uongsua">
                                        <img style="padding: 15% 15% 0 15%;" src="/images/uong.png" />
                                        <p style="font-size: 14px; font-weight: 600; top: -4%; position: relative;">
                                            Uống sữa
                                        </p>
                                    </label>
                                </div>
                                <div class="left-img-3" style="width: 32%; height: 91%; background-color: white; box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);">
                                    <input type="radio" id="cahai" value="anuong" onclick="myCheck(this.value)" name="choose" style="left: 79%; top: 9%;" />
                                   
                                    <label for="cahai">
                                        <img style="padding: 15% 15% 0 15%;" src="/images/an-uong.png" />
                                        <p style="font-size: 14px; font-weight: 600; top: -7%; position: relative;">
                                            Cả hai
                                        </p>
                                    </label>
                                </div>
                            </div>--%>
                            <div>
                                <a href="javascript:void(0)" class="btn btn-danger" id="btnDangKy" runat="server" onclick="DisplayLoadingIcon()" onserverclick="btnDangKy_ServerClick" style="display: flex; align-items: center; justify-content: center; margin: 2%;">Đăng ký
                                </a>
                                <a href="javascript:void(0)" class="btn btn-danger" id="btnHuyDangKy" runat="server" onclick="DisplayLoadingIcon()" onserverclick="btnHuyDangKy_ServerClick" style="display: flex; align-items: center; justify-content: center; margin: 2%; display: none">Hủy đăng ký
                                </a>
                            </div>

                            <div style="display: none;">
                                <input type="text" runat="server" id="txtTinhTrang" display="none" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container_right col-7" style="box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);">
                    <div class="">
                        <h2 class="container-right-title" style="color: #1f58c1">LỊCH SỬ ĐĂNG KÍ
                       <asp:Label ID="lblNam" runat="server"></asp:Label></h2>
                        <%--<asp:DropDownList ID="ddNam" runat="server">
                        </asp:DropDownList>--%>
                        <div>
                            <table class="table">
                                <tr>
                                    <th scope="col" class="nd">STT</th>
                                    <%--<th scope="col">Ngày đăng kí</th>--%>
                                    <th scope="col">Nội dung</th>
                                    <th scope="col">Tháng bắt đầu</th>
                                    <th scope="col">Trạng thái</th>
                                    <th scope="col">Chi tiết</th>
                                </tr>
                                <asp:Repeater ID="rpDanhSach" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td scope="row"><%#Container.ItemIndex+1 %></td>
                                            <%--<td><%#Eval("ansang_thangdangky","{0:dd/MM/yyyy}") %></td>--%>
                                            <td>Đăng kí ăn sáng, uống sữa</td>
                                            <td><%#Eval("ansang_thangdangky") %></td>
                                            <td><%#Eval("trangthai") %></td>
                                            <td>
                                                <a style="display: inline-block; background-color: unset !important; padding: 0 0; font-weight: 500; font-size: 14px; color: #28a745 !important; border: none; box-shadow: none;"
                                                    class="btn btn-success" data-toggle="modal" data-target="#myModal_<%#Eval ("ansang_id") %>">Xem
                                                </a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <tr id="txtKhongDuLieu" runat="server">
                                    <td colspan="5">Không có dữ liệu</td>
                                </tr>
                            </table>
                            <asp:Repeater ID="rpChiTiet" runat="server">
                                <ItemTemplate>
                                    <div class="modal fade" id="myModal_<%#Eval("ansang_id") %>" tabindex="-2" role="dialog" aria-labelledby="" aria-hidden="true">
                                        <div class="modal-dialog modal-dialog-centered">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h4 class="modal-title">Chi tiết đăng ký ăn sáng, uống sữa</h4>
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                </div>
                                                <div class="modal-body">
                                                    <span style="color: green; font-weight: 600">Tháng áp dụng: <%#Eval("ansang_thangdangky") %></span>
                                                    <div class="chon" style="display: flex; flex-direction: row; align-items: center;">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
