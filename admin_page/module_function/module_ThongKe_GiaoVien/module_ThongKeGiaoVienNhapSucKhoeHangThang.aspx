<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_ThongKeGiaoVienNhapSucKhoeHangThang.aspx.cs" Inherits="admin_page_module_function_module_ThongKe_GiaoVien_module_ThongKeGiaoVienNhapSucKhoeHangThang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />

    <script>
        function myCoSo(id) {
            DisplayLoadingIcon();
            document.getElementById("<%=txtCoSo_Id.ClientID%>").value = id;
            document.getElementById("<%=btnXemCoSo.ClientID%>").click();
        }
        function setActive(coso_id) {
            var element = document.getElementById("btnCoSo_" + coso_id);
            element.classList.add("mystyle");
        }
    </script>
    <style>
        .modal-backdrop.in {
            filter: alpha(opacity=50);
            opacity: -0.5;
            z-index: 0;
        }

        .close {
            display: none !important
        }

        .modal {
            z-index: 39;
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            padding-top: 100px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        .nav-tabs > li > a {
            color: black;
            text-decoration: auto;
            margin-right: 2px;
            line-height: 1.42857143;
            border: 1px solid transparent;
            border-radius: 4px 4px 0 0;
            font-weight: 600;
        }

        /* Modal Content */
        .modal-content {
            position: relative;
            background-color: #fefefe;
            margin: auto;
            padding: 0;
            border: 1px solid #888;
            width: 80%;
            box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2),0 6px 20px 0 rgba(0,0,0,0.19);
            -webkit-animation-name: animatetop;
            -webkit-animation-duration: 0.4s;
            animation-name: animatetop;
            animation-duration: 0.4s
        }

        /* Add Animation */
        @-webkit-keyframes animatetop {
            from {
                top: -300px;
                opacity: 0
            }

            to {
                top: 0;
                opacity: 1
            }
        }

        @keyframes animatetop {
            from {
                top: -300px;
                opacity: 0
            }

            to {
                top: 0;
                opacity: 1
            }
        }

        .modal-header {
            padding: 2px 16px;
            background-color: #5cb85c;
            color: white;
        }

        .modal-body {
            padding: 2px 16px;
        }

        .modal-footer {
            padding: 2px 16px;
            background-color: #5cb85c;
            color: white;
        }

        tr {
            text-align: center
        }

        .mystyle {
            background-color: red !important;
            border: none
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
    </style>
    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
        function HiddenLoadingIcon() {
            $("#img-loading-icon").hide();
        }
    </script>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <%--  <asp:UpdatePanel ID="upThongKe" runat="server">
        <ContentTemplate>--%>
    <div class="main-omt">
        <div class="omt-header">
            <i class="fa fa-user omt__icon" aria-hidden="true"></i>
            <h4 class="header-title">THỐNG KÊ GIÁO VIÊN NHẬP SỨC KHỎE HÀNG THÁNG</h4>
        </div>
    </div>
    <div class="card card-block">
        <div class="form-group row">
            <a href="/admin-danh-sach-thong-ke-danh-gia-giao-vien" class="btn btn-primary float-xs-right">Quay lại</a>
        </div>
        <asp:DropDownList ID="ddlThang" runat="server" onchange="DisplayLoadingIcon()" OnSelectedIndexChanged="ddlThang_SelectedIndexChanged" AutoPostBack="true" CssClass="ml-2">
            <%-- <asp:ListItem Value="Chọn tháng" Text="Chọn tháng" />
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
                    <asp:ListItem Value="12" Text="Tháng 12" />--%>
        </asp:DropDownList>
        <div class="form-group row" id="div_CoSo" runat="server">
            <asp:Repeater ID="rpCoSo" runat="server">
                <ItemTemplate>
                    <a href="javascript:void(0)" id="btnCoSo_<%#Eval("coso_id") %>" class="btn btn-success basicBox" onclick="myCoSo(<%#Eval("coso_id") %>)"><%#Eval("coso_name") %><p><%#Eval("solopdanhap") %>/<%#Eval("tongsolop") %></p>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="form-group table-responsive">
            <div class="tab-content">
                <table class="table table-bordered">
                    <tr class="thead-omt">
                        <th scope="col">#</th>
                        <th scope="col">Lớp</th>
                        <th scope="col">Ngày nhập</th>
                        <th scope="col">#</th>
                    </tr>
                    </tr>
                            <tbody>
                                <asp:Repeater ID="rpDSLopDaNhap" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th><%#Container.ItemIndex+1 %></th>
                                            <td><%#Eval("lop_name") %></td>
                                            <td><%#Eval("suckhoe_ngay","{0:dd/MM/yyyy}") %></td>
                                            <td>
                                                <a id="myBtn" data-toggle="modal" data-target="#exampleModal<%#Eval("lop_id") %>" class="btn btn-info" style="color: white; font-weight: 600">Xem chi tiết</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                </table>
                <asp:Repeater ID="rpChiTietSucKhoe" runat="server" OnItemDataBound="rpChiTietSucKhoe_ItemDataBound">
                    <ItemTemplate>
                        <div class="modal fade" id="exampleModal<%#Eval("lop_id") %>" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog" style="max-width: 100%; width: 888px;" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h2><%#Eval("lop_name") %></h2>
                                    </div>
                                    <div class="modal-body">
                                        <table class="table table-bordered">
                                            <tr class="tbheader">
                                                <th rowspan="2">STT</th>
                                                <th rowspan="2">Danh sách học sinh</th>
                                                <th colspan="2">Nhận xét sức khỏe</th>
                                                <th colspan="2">Ghi chú</th>
                                            </tr>
                                            <tr class="tbheader">
                                                <th>Cân nặng (kg)</th>
                                                <th>Chiều cao (cm)</th>
                                            </tr>
                                            <asp:Repeater ID="rpDanhSachHocSinh" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <th>
                                                            <%#Container.ItemIndex+1%>
                                                        </th>
                                                        <th>
                                                            <%#Eval("hocsinh_fullname")%>
                                                        </th>
                                                        <td>
                                                            <%#Eval("hocsinh_cannang") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("hocsinh_chieucao") %>
                                                        </td>
                                                         <td>
                                                            <%#Eval("hocsinh_ghichu") %>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
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
        <div style="display: none">
            <div>
                <input id="txtCoSo_Id" runat="server" />
                <a id="btnXemCoSo" runat="server" onserverclick="btnXemCoSo_ServerClick"></a>
            </div>
        </div>

    </div>
    <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

