<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DanhGiaGiaoVien_DanDoThuoc.aspx.cs" Inherits="admin_page_module_function_module_VietNhatKids_module_DanhGiaGiaoVien_TaoBaiVietAlbumAnh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>--%>
    <script>
        function myCoSo(id) {
            document.getElementById("<%=txtCoSo_Id.ClientID%>").value = id;
            if (id == 1) {
                var element = document.getElementById("btnCoSo_1");
                element.classList.add("mystyle");
                var element2 = document.getElementById("btnCoSo_2");
                element2.classList.remove("mystyle");
                var element3 = document.getElementById("btnCoSo_3");
                element3.classList.remove("mystyle");
            }
            if (id == 2) {
                var element = document.getElementById("btnCoSo_2");
                element.classList.add("mystyle");
                var element2 = document.getElementById("btnCoSo_1");
                element2.classList.remove("mystyle");
                var element3 = document.getElementById("btnCoSo_3");
                element3.classList.remove("mystyle");
            }
            if (id == 3) {
                var element = document.getElementById("btnCoSo_3");
                element.classList.add("mystyle");
                var element2 = document.getElementById("btnCoSo_1");
                element2.classList.remove("mystyle");
                var element3 = document.getElementById("btnCoSo_2");
                element3.classList.remove("mystyle");
            }
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <asp:UpdatePanel ID="upThongKe" runat="server">
        <ContentTemplate>
            <div class="main-omt">
                <div class="omt-header">
                    <i class="fa fa-user omt__icon" aria-hidden="true"></i>
                    <h4 class="header-title">Điểm tích lũy theo tháng</h4>
                </div>
            </div>
            <div class="card card-block">
                <div class="form-group row">
                    <div <%--style="display: flex; justify-content: space-around;"--%>>
                        <asp:Repeater ID="rpCoSo" runat="server">
                            <ItemTemplate>
                                <a href="javascript:void(0)" id="btnCoSo_<%#Eval("coso_id") %>" class="btn btn-success" onclick="myCoSo(<%#Eval("coso_id") %>)"><%#Eval("coso_name") %></a>
                            </ItemTemplate>
                        </asp:Repeater>
                        <a href="/admin-danh-sach-thong-ke-danh-gia-giao-vien" class="btn btn-primary float-xs-right">Quay lại</a>
                    </div>
                </div>
               
                <div class="form-group table-responsive">
                    <div class="tab-content">
                        <div ></div>
                            <h3><%=title_name %></h3>
                        <span>Lưu ý: Điểm tích lũy sẽ tính khi giáo viên xác nhận đơn dặn thuốc từ phụ huynh</span>
                            <table class="table table-bordered">
                                <thead class="thead-omt">
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Họ và Tên giáo viên</th>
                                        <th scope="col">Tổng số lần xác nhận</th>
                                        <th scope="col">Điểm tích lũy</th>
                                        <%--  <th scope="col">Ăn sáng</th>
                            <th scope="col">Uống sữa</th>--%>
                                        <th scope="col">#</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpDiemDanHangNgay" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <th><%=STTDiemDanhHangNgay++ %></th>
                                                <td><%#Eval("username_fullname") %></td>
                                                <td><%#Eval("TongSoLuongBaiTao")%>
                                                </td>
                                                <td><%#Eval("diemtichluy") %></td>
                                                <td>
                                                    <a id="myBtn" data-toggle="modal" data-target="#exampleModal<%#Eval("username_id") %>" class="btn btn-info" style="color: white; font-weight: 600">Xem chi tiết</a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        <asp:Repeater ID="rpGiaoVienNhaXetThuongXuyen" runat="server" OnItemDataBound="rpGiaoVienNhaXetThuongXuyen_ItemDataBound">
                            <ItemTemplate>
                                <div class="modal fade" id="exampleModal<%#Eval("username_id") %>" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                    <div class="modal-dialog" role="document">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h2><%#Eval("username_fullname") %></h2>
                                            </div>
                                            <div class="modal-body">
                                                <table class="table table-bordered">
                                                    <thead class="thead-omt">
                                                        <tr>
                                                            <th scope="col">#</th>
                                                            <%-- <th scope="col">Nhận xét thường xuyên</th>--%>
                                                            <th scope="col">Thời gian</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rpChiTietNhanXetHangNgay" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <th><%#Container.ItemIndex+1 %></th>
                                                                    <%-- <td><%#Eval("danhsachcongviec_name") %></td>--%>
                                                                    <td><%#Eval("phuhuynhdandothuoc_createdate", "{0: dd/MM/yyyy}") %></td>
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
                <div style="display: none">
                    <div>
                        <input id="txtCoSo_Id" runat="server" />
                        <a id="btnXemCoSo" runat="server" onserverclick="btnXemCoSo_ServerClick"> </a>
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

