<%@ Page Title="" Language="C#" MasterPageFile="~/Website_MasterPage.master" AutoEventWireup="true" CodeFile="web_DanThuoc.aspx.cs" Inherits="web_module_module_website_website_VietNhatKis_web_DanThuoc" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/Web_ThanhChucnang.ascx" TagPrefix="uc1" TagName="Web_ThanhChucnang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <%--<script src="../../js/owl.carousel.min.js"></script>--%>
    <link href="admin_css/css_index/Loading.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <script src="../../admin_js/sweetalert.min.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

    <style>
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

        /*.row {
            padding: 0 !important;*/
        /* height: 600px;*/
        /*margin-right: -87px;
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
                padding: 0.5rem;
                vertical-align: top;
                border-top: 1px solid #940808;
                padding: 5px;
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
            width: 70%;
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
            height: 31.75rem;
            border-radius: 10px;
            padding: 0 4%;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
            box-shadow: 2px 3px 8px 5px #80808029;
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

        .row {
            margin: 0;
            padding: 0 !important;
        }

        .fas.fa-check-circle {
            color: forestgreen;
        }

        .fas.fa-exclamation-circle {
            color: red;
        }

        a.disabled {
            pointer-events: none;
            cursor: default;
        }
    </style>
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
                <div class="container_left col-5 colrp" style="padding-left: 0">
                    <div class="block-bieudo" style="box-shadow: 2px 3px 8px 5px #80808029;">
                        <div id="block_Content">
                            <div>
                                <h4 style="padding-bottom: 20px;">DẶN THUỐC</h4>
                            </div>
                            <div class="flex-between" style="margin-bottom: 20px;">
                                <h6>Bệnh của con:</h6>
                                <input type="text" id="txtBenh" runat="server" class="inputBlock" />
                            </div>
                            <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                <h6>Từ ngày:</h6>
                                <input type="date" id="dteTuNgay" runat="server" class="inputBlock">
                            </div>
                            <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                <h6>Đến ngày:</h6>
                                <input type="date" id="dteDenNgay" runat="server" class="inputBlock">
                            </div>
                            <div class="flex-between" style="margin-bottom: 20px;">
                                <textarea id="txtDanDo" runat="server" class="inputBlock" style="height: 100%; border-radius: 8px; padding: 1%; width: 100%;" placeholder="Dặn dò..." rows="4"></textarea>
                            </div>
                            <div class="col-auto" style="display: flex; flex-direction: row-reverse; padding-right: 0">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <a href="#" style="display: block; background: #a10101;" class="btn btn-lg btn-success" id="btnGui" runat="server" text="Gửi" onserverclick="btnGui_Click">Gửi</a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container_right col-7" style="box-shadow: 2px 3px 8px 5px #80808029;">
                    <div>
                        <h4 style="font-size: 20px; font-weight: bold; color: #1f58c1; text-transform: uppercase; margin-bottom:2%; /* color: aqua; */">Lịch sử dặn thuốc năm <span class="year">
                            <asp:Label ID="lblNam" runat="server"></asp:Label></span></h4>
                    </div>
                    <div>
                        <div>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">STT</th>
                                        <th scope="col">Ngày dặn</th>
                                        <th scope="col">Bệnh</th>
                                        <th scope="col">Trạng thái</th>
                                        <th scope="col">Cập nhật</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpDanThuoc" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td scope="row"><%= stt++ %></td>
                                                <td><%# Eval("danthuoc_RegisterDate","{0:dd/MM/yyyy}") %></td>
                                                <td><%# Eval("danthuoc_disease") %></td>
                                                <td><%#Eval("danthuoc_status")%></td>
                                                <td>
                                                    <a style="display: inline-block; background-color: unset !important; border: unset !important; padding: 0; font-weight: 700; color: #28a745 !important;"
                                                        class="btn btn-success" data-toggle="modal" data-target="#myModal_<%#Eval ("danthuoc_id") %>">
                                                        <%--Cập nhật--%>
                                                       
                                                        <i title="Chỉnh sửa"  class="fa fa-pen"></i> 
                                                        <i title="Đã chỉnh sửa" id="pen" class="fa fa-pen" style="display:none"></i>
                                                    </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>--%>
    <asp:Repeater ID="rpChiTietDanThuoc" runat="server">
        <ItemTemplate>
            <div class="modal fade" id="myModal_<%#Eval("danthuoc_id") %>" tabindex="-1" role="dialog" aria-labelledby="" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Chi tiết dặn thuốc</h4>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <div class="flex-between" style="margin-bottom: 20px;">
                                <h6 style="margin-bottom: 0; text-align: left;">Bệnh của con:</h6>
                                <input type="text" onkeypress="key()" id="txtTenBenh_<%#Eval("danthuoc_id") %>" class="inputBlock" value="<%#Eval("danthuoc_disease") %>" />
                            </div>
                            <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                <h6 style="margin-bottom: 0; text-align: left;">Từ ngày:</h6>
                                <input type="date" onkeypress="key()" id="txtTuNgay_<%#Eval("danthuoc_id") %>" value="<%# Eval("danthuoc_StartDate", "{0:yyyy-MM-dd}")%>" class="inputBlock">
                            </div>
                            <div class="flex-between position-relative" style="margin-bottom: 20px;">
                                <h6 style="margin-bottom: 0; text-align: left;">Từ ngày:</h6>
                                <input type="date" onkeypress="key()" id="txtDenNgay_<%#Eval("danthuoc_id") %>" value="<%#Eval("danthuoc_EndDate", "{0:yyyy-MM-dd}") %>" class="inputBlock">
                            </div>

                            <div class="flex-between" style="margin-bottom: 20px;">
                                <textarea class="inputBlock" onkeypress="key()" id="txtNoiDungDanDo_<%#Eval("danthuoc_id") %>" style="height: 100%; width: 100%; padding: 2%; }"
                                    placeholder="Dặn dò..." rows="4"><%#Eval("danthuoc_content") %></textarea>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <a href="javascript:void(0)" id="cn" onclick="myCapNhat('<%#Eval("danthuoc_id") %>')" style="display: block" class=" btn btn-danger">Cập nhật</a>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <input type="text" runat="server" id="txtIDCapNhat" hidden="hidden" />
    <input type="text" runat="server" id="txtTenCapNhat"  hidden="hidden" />
    <input type="text" runat="server" id="txtNgayDkCapNhat" hidden="hidden" />
    <input type="text" runat="server" id="txtNgayBDCapNhat" hidden="hidden" />
    <input type="text" runat="server" id="txtNgayKTCapNhat" hidden="hidden" />
    <input type="text" runat="server" id="txtNDCapNhat" hidden="hidden" />
    <a href="javascript:void(0)" runat="server" id="btnCapNhat" onserverclick="btnCapNhat_ServerClick" style="display: none" class="btn btn-danger">Sửa nội dung dặn thuốc</a>

    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
        function myCapNhat(id) {
            DisplayLoadingIcon();
            document.getElementById('<%=txtIDCapNhat.ClientID%>').value = id;
            document.getElementById('<%=txtTenCapNhat.ClientID%>').value = document.getElementById('txtTenBenh_' + id).value;
            document.getElementById('<%=txtNgayBDCapNhat.ClientID%>').value = document.getElementById('txtTuNgay_' + id).value;
            document.getElementById('<%=txtNgayKTCapNhat.ClientID%>').value = document.getElementById('txtDenNgay_' + id).value;
            console.log(document.getElementById('txtTenBenh_' + id).value);
            console.log(document.getElementById('txtTuNgay_' + id).value);
            console.log(document.getElementById('txtDenNgay_' + id).value);
            console.log(document.getElementById('txtNoiDungDanDo_' + id).value);
            document.getElementById('<%=txtNDCapNhat.ClientID%>').value = document.getElementById('txtNoiDungDanDo_' + id).value;
            document.getElementById('<%=btnCapNhat.ClientID%>').click();


        }
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
</asp:Content>











