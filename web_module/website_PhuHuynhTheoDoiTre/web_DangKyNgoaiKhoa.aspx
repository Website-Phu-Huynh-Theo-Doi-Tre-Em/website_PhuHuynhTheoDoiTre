﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Website_MasterPage_MamNon.master" AutoEventWireup="true" CodeFile="web_DangKyNgoaiKhoa.aspx.cs" Inherits="web_module_module_website_website_VietNhatKis_web_DangKyNgoaiKhoa" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/Web_VietNhatKids.ascx" TagPrefix="uc1" TagName="Web_VietNhatKids" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/2.1.2/sweetalert.min.js"></script>
    <script src="../../admin_js/sweetalert.min.js"></script>
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <style>
        body {
            background-color: #e7e7e8;
            /*display: flex;
            align-items: center;
            float: right;*/
            /*justify-content: space-between;*/
            /*flex-direction: row;
            align-content: center;
            flex-wrap: nowrap;*/
        }


        .container-left {
            height: 32rem;
            display: flex;
            flex-direction: column;
            background-image: url(/images/DangKyNgoaiKhoa/dangkyngoaikhoa-1.png);
            background-size: cover;
            background-repeat: no-repeat;
            border-radius: 10px;
            box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);
            margin: 0 3%;
            overflow: auto;
            flex-wrap: nowrap;
            justify-content: center;
            align-items: center;
        }

            .container-left .left-section {
                background-color: white;
                top: 94px;
                position: relative;
                border-radius: 8px;
                margin: 0 4%;
                height: 29.1%;
                width: 91%;
                box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);
                padding: 3%;
                margin: 1% 0;
            }

            .container-left h2 {
                font-size: 15px;
                font-weight: 600;
            }

        .section .container-left p {
            font-size: 12px;
            color: #464b50;
        }

        .button {
            font-size: 16px;
            background-color: #BD3232;
            border-radius: 20px;
            width: 31%;
            border: none;
            color: #FFFFFF;
            padding: 1px;
            font-weight: 500;
        }

        .container-left a {
            font-size: 18px;
            padding: 0 2%;
        }

        .container-right {
            height: 32rem;
            /*background-image: url(/images/DangKyNgoaiKhoa/dangkyngoaikhoa-1.png);*/
            background-color: white;
            background-size: cover;
            background-repeat: no-repeat;
            border-radius: 10px;
            padding: 12% 11%;
            /*  margin: 0 1%;*/
            box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);
            overflow: auto;
        }

            .container-right h2 {
                font-size: 19px;
                color: #c3a734;
            }

        .block-title {
            font-size: 17px;
            font-weight: 500;
        }

        .block-sec {
            font-weight: normal;
            font-size: 15px;
        }


        .container-right .img {
            margin: 0 -10%;
            position: relative;
            top: 11%;
        }

        .btn-left button {
            background-color: #BD3232;
            border-radius: 15px;
            padding: 0 2%;
            border: none;
            color: #FFFFFF;
            font-size: 15px;
            font-weight: 500;
        }

        .btn-left .block {
            display: flex;
            flex-direction: row-reverse;
            flex-wrap: nowrap;
            align-content: center;
            justify-content: flex-start;
            align-items: center;
            margin: -6% 0;
        }

        .btn-dangki {
            background: #B51A1A;
            border-radius: 4px;
            align-items: center;
            color: #FFFFFF !important;
            font-weight: 600;
            font-size: 18px;
            line-height: 21px;
            padding: 2px 8px;
        }

        .btn-canceldangki {
            background: #B51A1A;
            border-radius: 4px;
            align-items: center;
            color: #FFFFFF !important;
            font-weight: 600;
            font-size: 18px;
            line-height: 21px;
            padding: 2px 8px;
        }

        a {
            text-decoration: none !important;
        }

        .btn_detail {
            text-align: right;
            float: right;
            padding-right: 2%;
            color: #007bff !important;
        }

            .btn_detail:hover {
                color: red !important;
                cursor: pointer;
            }

        .half-circle-ribbon {
            background: #86d729;
            color: #FFF;
            height: 29px;
            width: 45px;
            text-align: right;
            top: -1px;
            padding: unset !important;
            /*z-index: 1000;*/
            right: -1px;
            position: absolute;
            font-size: 17px;
            flex-direction: row;
            border-radius: 0 0 0 100%;
            /* border: 1px dashed #FFF; */
            box-shadow: 0 0 0 3px #4caf50;
        }

        .container-left {
            height: 32rem;
            display: flex;
            flex-direction: column;
            background-image: url(/images/DangKyNgoaiKhoa/dangkyngoaikhoa-1.png);
            background-size: cover;
            background-repeat: no-repeat;
            border-radius: 10px;
            box-shadow: 0px 4px 4px rgb(0 0 0 / 25%);
            margin: 0 3%;
            /* overflow: auto; */
            /* flex-wrap: nowrap; */
            justify-content: flex-start;
            align-items: center;
        }

        .left-title {
            color: #cc3333;
        }

        a:hover {
            text-decoration: none
        }

        .row {
            margin: 0;
            padding: 0 !important
        }
    </style>

    <script>
        $(document).ready(function () {
          //  if (document.getElementById("<%=txtngoaiKhoa_id.ClientID%>").value != "") {
          var id = document.getElementById("<%=txtngoaiKhoa_id.ClientID%>").value;
          document.getElementById("div_" + id).style.backgroundColor = "#bcdae5";
          //  } else {
          //      var id = document.getElementById("<%=txtngoaikhoa_id_moinhat.ClientID%>").value;
          //     document.getElementById("div_" + id).style.backgroundColor = "#ffa1a1";
          //  }

      });

        function confirmDel(id) {
            var hocsinh = document.getElementById("<%=txtHocSinh.ClientID%>").value;
            swal("Ba mẹ bé " + hocsinh + " có thực sự muốn đăng ký?",
                "",
                "warning",
                {
                    buttons: ["Không đồng ý", "Đồng ý"],
                    successMode: true,
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtngoaiKhoa_id.ClientID%>").value = id;
                        var xoa = document.getElementById('<%=btnSave.ClientID%>');
                        xoa.click();
                    }
                });
        }
        function confirmHuyDangKi(id) {
            var hocsinh = document.getElementById("<%=txtHocSinh.ClientID%>").value;
            swal("Ba mẹ bé " + hocsinh + " có thực sự không muốn đăng ký?",
                "",
                "warning",
                {
                    buttons: ["Không đồng ý", "Đồng ý"],
                    successMode: true,
                }).then(function (value) {
                    if (value == true) {
                        document.getElementById("<%=txtngoaiKhoa_id.ClientID%>").value = id;
                        var xoa = document.getElementById('<%=btnKhongDangKy.ClientID%>');
                        xoa.click();
                    }
                });
        }
        function funcgetID(dangoai_id) {
            console.log(dangoai_id);
            document.getElementById("<%=txtngoaiKhoa_id.ClientID%>").value = dangoai_id;
            document.getElementById("<%=btnXem.ClientID%>").click();
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
                <uc1:Web_VietNhatKids runat="server" ID="Web_VietNhatKids" />
            </div>
            <div class="col-12 row" style="padding: 0">
                <div class="col-5" style="padding: 0;">
                    <div class="container-left" style="margin-left: 0">
                        <asp:Repeater runat="server" ID="rpDaNgoai">
                            <ItemTemplate>
                                <div class="left-section" id="div_<%#Eval("ngoaikhoa_id") %>" style="">
                                    <div class="half-circle-ribbon" style="<%#Eval("style")%>">Mới</div>
                                    <div>
                                        <h6 class="left-title"><%#Eval("ngoaikhoa_name")%></h6>
                                    </div>
                                    <p class="left-sec" style="font-size: 14px"><%#Eval("ngoaikhoa_description")%></p>
                                    <div class="btn-left" style="padding: 0 1%;">
                                        <%--      <a style="" id="btnLuu" href="javascript:void(0)" class="btn-dangki" onclick="confirmDel(<%#Eval("ngoaikhoa_id") %>)">Đăng ký</a>
                                        <a style="" id="btnHuy" href="javascript:void(0)" class="btn-canceldangki" onclick="confirmHuyDangKi(<%#Eval("ngoaikhoa_id") %>)">Không đăng ký</a>
                                        --%>
                                        <a onclick="funcgetID(<%#Eval("ngoaikhoa_id") %>)" class="btn_detail">Xem chi tiết</a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div style="display:none">
                            <input type="text" id="txtngoaiKhoa_id" runat="server" placeholder="click" style="" />
                            <input type="text" id="txtngoaikhoa_id_moinhat" placeholder="moi_nhat" runat="server" />
                            <input type="text" id="txtHocSinh" runat="server" style="" />
                            <a id="btnXem" runat="server" onserverclick="btnXem_ServerClick"></a>
                            <a id="btnSave" runat="server" onserverclick="btDangKy_ServerClick"></a>
                            <a id="btnKhongDangKy" runat="server" onserverclick="btnKhongDangKy_ServerClick"></a>
                        </div>
                    </div>
                </div>
                <div class="col-7" style="padding: 0">
                    <div class="container-right">
                        <asp:Repeater runat="server" ID="rpDaNgoaiChiTiet">
                            <ItemTemplate>
                                <div class="left-section">
                                    <div>
                                        <h3 class="left-title"><%#Eval("ngoaikhoa_name")%></h3>
                                    </div>
                                    <p class="left-sec" style="font-size: 18px"><%#Eval("ngoaikhoa_content")%></p>
                                    <div class="btn-left" style="padding: 0 1%;">
                                        <a id="btnLuu" href="javascript:void(0)" class="btn-dangki" onclick="confirmDel(<%#Eval("ngoaikhoa_id") %>)">Đăng ký</a>
                                        <a id="btnHuy" href="javascript:void(0)" class="btn-canceldangki" onclick="confirmHuyDangKi(<%#Eval("ngoaikhoa_id") %>)">Hủy đăng ký</a>
                                        <a id="btnTuVan" href="javascript:void(0)" class="btn-tuvan" runat="server" onserverclick="btnTuVan_ServerClick">Tư vấn thêm</a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</asp:Content>

