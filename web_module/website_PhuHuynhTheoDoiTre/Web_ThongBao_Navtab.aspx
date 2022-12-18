<%@ Page Title="" Language="C#" MasterPageFile="~/Website_MasterPage.master" AutoEventWireup="true" CodeFile="Web_ThongBao_Navtab.aspx.cs" Inherits="web_module_website_Web_ThongBao_Navtab" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/Web_ThanhChucnang.ascx" TagPrefix="uc1" TagName="Web_ThanhChucnang" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
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
            margin: 0.75% 0;
            display: flex;
            flex-direction: column;
            flex-wrap: nowrap;
            justify-content: space-around;
            text-align: center;
        }

        .container_right {
            border-radius: 10px;
            padding: 1%;
            /* overflow: auto;*/
            margin-left: 0;
            max-height: 28rem;
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

        .row {
            padding: 0 !important;
        }

        .table {
            width: 100% !important;
            text-align: center;
            /*overflow: auto;*/
        }

            .table td, .table th {
                padding: 0.5rem;
                vertical-align: top;
            }

        th {
            text-align: inherit;
            border: 1px solid white;
            padding: 0.5%;
            color: white;
            background: #a10101;
            font-weight: 500;
            font-size: 17px;
        }

        .table-dongphuc td {
            border: 0.5px solid gray;
        }

        .table-dongphuc {
            margin: 1% auto;
            width: 98%;
        }

        .box__modal .table {
            width: 100%;
            text-align: center;
        }

        .block-bieudo {
            height: 32rem;
            /* overflow: auto; */
            background-color: #ffffff;
            /* width: 100%; */
            height: 31.75rem;
            border-radius: 10px;
            padding: 1%;
        }

        .block_Title {
            font-weight: 600;
        }

        .table td {
            /*border-bottom: 1px solid #f1ae98;*/
        }

        .gui {
            background-color: #BD3232;
            border-radius: 6px;
            width: 100%;
            font-weight: 600;
            height: 41px;
            display: flex;
            margin: 4% 0;
            border: none;
            color: #FFFFFF;
            padding: 3px;
            box-shadow: 0px 2px 1px 1px rgb(0 0 0 / 25%);
            justify-content: center;
            align-items: center;
        }

        .đo-dung {
            width: 100%;
        }

            .đo-dung td {
                border: 1px solid black;
            }

                .đo-dung td input {
                    border: none !important;
                }

        .btn_Gui {
            height: 40px;
            padding: 8px 20px;
            text-align: center;
            background: #B51A1A;
            color: #fff;
            border: none;
            outline: none;
            border-radius: 8px;
            font-weight: 600;
            box-shadow: 0 1px 2px #999;
            cursor: pointer;
            float: right;
            margin-right: 1%;
        }

        .nav-link {
            display: block;
            padding: .2rem 0.5rem;
        }

        .nav {
            display: -webkit-box;
            display: -ms-flexbox;
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: nowrap;
            padding-left: 0;
            margin-bottom: 0;
            list-style: none;
            flex-direction: row;
        }

        .nav-pills .nav-link.active, .nav-pills .show > .nav-link {
            color: #fff;
            background-color: #940808;
            /*background-color: #9c27b0;*/
            box-shadow: 0 5px 20px 0 rgb(0 0 0 / 20%), 0 13px 24px -11px rgb(161 1 1);
        }


        a:hover {
            color: #940808;
            text-decoration: underline;
        }

        a {
            color: #940808;
        }

        .other-information {
            display: none;
            width: 84%;
            margin-top: 1%;
            margin-left: -1.5%;
            justify-content: center;
            margin-left: 7%;
        }

        .h6-height-width {
            margin-bottom: 0;
            width: 100%;
            text-align: center;
            font-size: 17px;
            margin-top: 7%;
            margin-left: -10%;
        }

        .inputBlock {
            width: 80%;
            height: 59%;
            margin-top: 5%;
            margin-left: -10%;
            border: none;
            border-bottom: 1px solid;
            text-align: center;
        }

        .content-other {
            display: flex;
            margin-bottom: 0;
            margin-left: 0;
        }

        .main_Dangky {
            display: flex !important;
        }

        .mb-3, .my-3 {
            margin-bottom: 0.5rem !important;
        }

        .btn-Xem {
            color: #28a745 !important;
            font-weight: 700;
            background: none;
            border: none
        }

            .btn-Xem:hover {
                color: #198531 !important;
                font-weight: 700;
                background-color: none !important;
                border-color: none !important;
            }

        .tab-content {
            height: 27rem;
            overflow: auto;
        }

        .ThongBaoGanNhat {
            font-size: 10px;
            margin-left: 15px;
            margin-right: 15px;
        }

        /*.notification_chinh {
            margin-top: 60px;
            margin-left: -10px;
        }*/

        .tb {
            color: #b52221;
            font-size: 15px;
            font-weight: 500;
            border-bottom: 1px solid #c7c7c7;
            height: 30px;
            display: flex;
        }

        .titlee {
            color: #B51A1A;
            font-size: 15px;
        }

        .hi {
            font-size: 14px;
            margin-left: 10px;
            overflow: hidden;
            display: -webkit-box;
            -webkit-line-clamp: 1;
            -webkit-box-orient: vertical;
        }

        .notification a {
            color: #000;
            font-weight: 500;
            padding: 3px 0px;
            border-bottom: 1px dashed #D73932;
            display: flex;
            align-items: center;
            text-decoration: none;
        }

        .NoiDung {
            margin: 0 5%;
            /* overflow: auto;
            height: 25rem;*/
        }

        .Normal {
            text-align: justify;
        }

        .new_thongbao {
            color: red;
            background-color: yellow;
        }

        .thongbao_con:hover {
            cursor: pointer;
            color: #b52221 !important;
            font-weight: 600
        }

        .row {
            margin: 0;
        }

        .row {
            display: flex;
            justify-content: center;
        }

        .ThongBaoGanNhat {
            flex-direction: column;
        }

        .row h2 {
            width: 100%;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid row">
        <div class="col-xl-3 col-md-12 float-left">
            <uc1:Web_ThongTinCaNhan runat="server" ID="Web_ThongTinCaNhan" />
        </div>
        <div class="col-xl-9 col-md-12">
            <div class="col-xl-12 col-md-12 userrp" style="padding: 0">
                <uc1:Web_ThanhChucnang runat="server" ID="Web_ThanhChucnang" />
            </div>
            <div class="col-12 row" style="padding: 0; margin: 0">
                <div class="container_left col-12" style="padding: 0">
                    <div class="block-bieudo" style="box-shadow: 2px 3px 8px 5px #80808029;">
                        <ul class="nav mb-3 nav-pills" id="pills-tab" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" onclick="myNotification('thongbaotruong')" id="v-pills-messages-tab" data-toggle="pill" href="#thong-bao-truong" role="tab" aria-controls="v-pills-messages" aria-selected="true">Thông báo trường</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="pills-profile-tab" onclick="myNotification('thongbaolop')" data-toggle="pill" href="#thong-bao-lop" role="tab" aria-controls="pills-profile" aria-selected="false">Thông báo lớp</a>
                            </li>
                        </ul>
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="thong-bao-truong" role="tabpanel" aria-labelledby="v-pills-messages-tab">
                                <div class="container-Truong">
                                    <div class="NoiDung">
                                        <div class="row">
                                            <asp:Repeater ID="rpThongBaoChiTiet" runat="server">
                                                <ItemTemplate>
                                                    <h2 id="<%#Eval("thongbao_id") %>" class="hidden"><%#Eval("thongbao_title") %></h2>
                                                    <%#Eval("thongbao_content") %>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div class=" row ThongBaoGanNhat">
                                            <div class="tb">THÔNG BÁO GẦN NHẤT</div>
                                            <asp:Repeater ID="rpThongBao" runat="server">
                                                <ItemTemplate>
                                                    <div class="notification">
                                                        <a class="thongbao_con" onclick="funcXem(<%#Eval("thongbao_id")%>) ">
                                                            <span class="titlee">[<%=STT++ %>]</span>
                                                            <span class="hi"><%#Eval("thongbao_title") %></span>
                                                            <%--<span class="new_thongbao" style="<%#Eval("style")%>">New</span>--%>
                                                        </a>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <a id="btnXemThongBaoTruong" runat="server" onserverclick="btnXemThongBaoTruong_ServerClick"></a>
                                    <input hidden="hidden" id="txtID" runat="server" />
                                </div>
                            </div>
                            <div class="tab-pane fade" id="thong-bao-lop" role="tabpanel" aria-labelledby="pills-profile-tab">
                                <div class="container-Lop">
                                    <div class="NoiDung">
                                        <div class="row">
                                            <asp:Repeater ID="rpThongBaoChiTietLop" runat="server">
                                                <ItemTemplate>
                                                    <h2 style="width: 100%;" class="hidden"><%#Eval("thongbao_title") %></h2>
                                                    <div style="text-align: justify"><%#Eval("thongbao_content") %></div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <div class="row ThongBaoGanNhat">
                                            <div class="tb">THÔNG BÁO GẦN NHẤT</div>
                                            <asp:Repeater ID="rpThongBaoLop" runat="server">
                                                <ItemTemplate>
                                                    <div class="notification">
                                                        <a class="thongbao_con" onclick="funXemTBLop(<%#Eval("thongbao_id")%>)">
                                                            <span class="titlee">[<%=STTT++ %>]</span>
                                                            <span class="hi"><%#Eval("thongbao_title") %></span>
                                                            <%--<span class="new_thongbao" style="<%#Eval("style")%>">New</span>--%>
                                                        </a>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <a id="btn_ThongBaoLop" runat="server" onserverclick="btn_ThongBaoLop_ServerClick"></a>
                                    <input hidden="hidden" id="txtIDTBLop" runat="server" />
                                </div>
                            </div>
                        </div>
                        <input type="text" id="txtLoaiThongBao" runat="server" hidden />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        //func set active thông báo lớp
        function myNotification(thongbao) {
            document.getElementById("<%=txtLoaiThongBao.ClientID%>").value = thongbao;
        }
        $(document).ready(function () {
            let thongbao = document.getElementById("<%=txtLoaiThongBao.ClientID%>").value;
            var elems = document.querySelector(".nav-link");
            var elems_content = document.querySelector(".tab-pane");
            if (elems !== null)
                elems.classList.remove("active", "show");
            if (elems_content !== null)
                elems_content.classList.remove("active", "show");
            //debugger;
            if (thongbao == "thongbaolop") {
                $("#pills-profile-tab").addClass("active show")
                $("#thong-bao-lop").addClass("active show");
            }
            else {
                //$("v-pills-messages-tab").classList.add("active", "show");
                $("#v-pills-messages-tab").addClass("active show")
                $("#thong-bao-truong").addClass("active show");
            }
        });
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
        function funcXem(id) {
            document.getElementById("<%=txtID.ClientID%>").value = id;
            document.getElementById("<%=btnXemThongBaoTruong.ClientID%>").click();
            DisplayLoadingIcon();
        } function funXemTBLop(id) {
            document.getElementById("<%=txtIDTBLop.ClientID%>").value = id;
            document.getElementById("<%=btn_ThongBaoLop.ClientID%>").click();
        }
        function refresh() {
            location.reload();
        }

    </script>
</asp:Content>




