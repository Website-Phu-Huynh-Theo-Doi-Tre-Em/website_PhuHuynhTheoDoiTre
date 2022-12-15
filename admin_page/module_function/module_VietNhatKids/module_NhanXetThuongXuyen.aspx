<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_NhanXetThuongXuyen.aspx.cs" Inherits="admin_page_module_function_module_VietNhatKids_module_NhanXetGiaoVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script>
        function myClick1(value, id) {
            if (document.getElementById("ck01" + id).checked == true) {
                document.getElementById("txt" + id).value = document.getElementById("txt" + id).value + "-" + value + "\n";
            }
            else {
                let str = document.getElementById("txt" + id).value;
                let res = str.replace("-" + value + "\n", "");
                document.getElementById("txt" + id).value = res;
            }
        }
        function myClick2(value, id) {
            if (document.getElementById("ck02" + id).checked == true) {
                document.getElementById("txt" + id).value = document.getElementById("txt" + id).value + "-" + value + "\n";
            }
            else {
                let str = document.getElementById("txt" + id).value;
                let res = str.replace("-" + value + "\n", "");
                document.getElementById("txt" + id).value = res;
            }
        }
        function myClick3(value, id) {
            if (document.getElementById("ck03" + id).checked == true) {
                document.getElementById("txt" + id).value = document.getElementById("txt" + id).value + "-" + value + "\n";
            }
            else {
                let str = document.getElementById("txt" + id).value;
                let res = str.replace("-" + value + "\n", "");
                document.getElementById("txt" + id).value = res;
            }
        }
        function myClick4(value, id) {
            if (document.getElementById("ck04" + id).checked == true) {
                document.getElementById("txt" + id).value = document.getElementById("txt" + id).value + "-" + value + "\n";
            }
            else {
                let str = document.getElementById("txt" + id).value;
                let res = str.replace("-" + value + "\n", "");
                document.getElementById("txt" + id).value = res;
            }
        }
        function myClick5(value, id) {
            if (document.getElementById("ck05" + id).checked == true) {
                document.getElementById("txt" + id).value = document.getElementById("txt" + id).value + "-" + value + "\n";
            }
            else {
                let str = document.getElementById("txt" + id).value;
                let res = str.replace("-" + value + "\n", "");
                document.getElementById("txt" + id).value = res;
            }
        }
        function myClick6(value, id) {
            if (document.getElementById("ck06" + id).checked == true) {
                document.getElementById("txt" + id).value = document.getElementById("txt" + id).value + "-" + value + "\n";
            }
            else {
                let str = document.getElementById("txt" + id).value;
                let res = str.replace("-" + value + "\n", "");
                document.getElementById("txt" + id).value = res;
            }
        }
    </script>
    <link rel="stylesheet" href="../../../web_VietNhatKids_css/SoLienLacDienTu/base.css" />
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <style>
        .dateCreate span {
            font-size: 20px;
            margin-right: 40px;
        }

        .table-bordered {
            border: none;
        }

            .table-bordered th, .table-bordered td {
                text-align: center;
            }

        .btnCalender {
            padding: 12px;
            color: #fff !important;
        }

        .table_baogiang th, .table_baogiang td {
            text-align: center;
            border: 1px solid #2d3846;
        }

        .table tr.tbheader {
            background: #a3a7a199;
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
            font-size: 20px;
            padding: 10px 10px;
            color: white;
        }

        .modal__detail {
            position: fixed;
            background-color: rgba(0,0,0,0.6);
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            z-index: 99;
            opacity: 0;
            visibility: hidden;
            transition: all 0.2s linear;
        }

            .modal__detail.active {
                opacity: 1;
                visibility: visible;
            }

        .box-modal {
            width: 70%;
            height: 300px;
            display: block;
            position: absolute;
            top: 75%;
            left: 50%;
            transform: translate(-50%,-50%);
            border-radius: 16px;
            background-color: #fff;
            outline: none;
            opacity: 0;
            visibility: hidden;
            transition: all 0.2s linear;
            overflow: auto;
            padding: 10px;
        }

            .box-modal.active {
                opacity: 1;
                visibility: visible;
                top: 50%;
            }

            .box-modal .name {
                font-weight: bold;
                color: #1f58c1;
                text-align: center;
                margin-top: 15px;
                margin: 0;
            }



            .box-modal .btn__dong {
                float: right;
            }

        a.hocsinh__active {
            color: #ffffff !important;
            background-color: #FF4444 !important;
            border-color: #FF4444 !important;
        }

        .button__disable {
            cursor: not-allowed;
            pointer-events: none;
        }
    </style>
    <style>
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

        a.hocsinh__active {
            color: #ffffff !important;
            background-color: #FF4444 !important;
            border-color: #FF4444 !important;
        }

        .button__disable {
            cursor: not-allowed;
            pointer-events: none;
        }

        .modal-body {
            padding: unset;
        }

        .modal-dialog {
            max-width: 64rem;
            margin: 4% auto;
        }

        .fade.in {
            background: #80808059;
            opacity: 1;
        }

        .modal .modal-content {
            border-radius: 0;
            background: unset;
            border: none;
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
    <div class="main-omt">
        <div class="omt-header">
            <i class="fa fa-list-alt omt__icon" aria-hidden="true"></i>
            <h4 class="header-title">Nhận xét hoạt động học tập trong ngày&nbsp; (<%=DateTime.Now.ToShortDateString() %>)</h4>
        </div>
         <div class="mt-2" id="div_Notification" runat="server">
            <h3 style="color: red; text-align: center">Giáo viên vui lòng vào điểm danh học sinh trước khi nhận xét!</h3>
        </div>
        <div class="card card-block" id="div_KetQua" runat="server">
            <div class="" style="margin: 20px 0; display: flex; align-items: center; justify-content: space-between;">
                <div class="dateCreate" style="display: flex; align-items: center">
                    <asp:Label ID="lblDateCreate" runat="server">
                    </asp:Label>
                    <div style="display: flex; align-items: center;">
                        <h5 style="margin-right: 12px;">Lớp:</h5>
                        <h5 style="margin-bottom: 0">
                            <asp:Label ID="rpSetLop" runat="server">
                            </asp:Label>
                        </h5>
                    </div>
                </div>
                <div>
                    <a href="#" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">File hướng dẫn</a>
                    <a href="/admin-home" class="btn btn-primary">Quay lại</a>
                </div>
            </div>
            <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <embed src="../../../file_huongdan/nhan_xet_hoc_tap_trong_ngay.pdf" width="1030" height="650" type="application/pdf" />
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <p>1. Con thuộc thơ và tập trung khi học toán tuy nhiên con cần cố gắng ngồi nghiêm túc trên ghế để lắng nghe cô hướng dẫn bài nhé!</p>
                <p>2. Con thích nghe cô kể chuyện và nhanh tay xung phong trả lời câu hỏi của cô, con phát huy hơn nữa nhé! Yêu con!</p>
                <p>3. Hôm nay tâm trạng của con chưa tốt nên các hoạt động chưa sôi nổi. Cô mong ngày mai con sẽ thật vui qua các hoạt động nhé!</p>
                <p>4. Hôm nay con rất cố gắng với vận động “Đu xà”, con đã thực hiện tốt vận động. Cô khen con!</p>
                <p>5. Trong giờ tạo hình con tập trung, con biết sử dụng các nguyên vật liệu khác nhau để tạo thành bức tranh rất nhiều màu sắc.</p>
                <p>6. Hôm nay con thích thú khi được tham gia “hoạt động ngoài trời” Con đã giơ tay trả lời được câu hỏi của cô khi quan sát về “thời tiết” và chơi trò chơi vận động với các bạn thật vui!</p>
            </div>
            <div style="margin-left: 20px; color: blue;">
                <span>Lưu ý:</span><br />
                <span>- Để nội dung hiển thị xuống hàng, giáo viên cần nhập dấu gạch ngang (-) trước nội dung.</span>
            </div>
            <div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <table border="1" cellspacing="0" cellpadding="5" class="table table-bordered table_baogiang">
                            <tr class="tbheader">
                                <th>STT</th>
                                <th>Danh sách học sinh</th>
                                <th>Nhận xét hoạt động học tập</th>
                                <th>Nội dung</th>
                            </tr>
                            <asp:Repeater ID="rpDanhSachHocSinh" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <th>
                                            <%=STT++%>
                                        </th>
                                        <th>
                                            <%#Eval("hocsinh_name")%>
                                        </th>
                                        <th>
                                            <div style="display: flex; justify-content: space-evenly">
                                                <label class="mr-2">
                                                    <input type="checkbox" id="ck01<%#Eval("hstl_id")%>" onclick="myClick1(this.value, <%#Eval("hstl_id")%>)" value="Con thuộc thơ và tập trung khi học toán tuy nhiên con cần cố gắng ngồi nghiêm túc trên ghế để lắng nghe cô hướng dẫn bài nhé!" />
                                                    1
                                                </label>
                                                <label class="mr-2">
                                                    <input type="checkbox" id="ck02<%#Eval("hstl_id")%>" onclick="myClick2(this.value, <%#Eval("hstl_id")%>)" value="Con thích nghe cô kể chuyện và nhanh tay xung phong trả lời câu hỏi của cô, con phát huy hơn nữa nhé! Yêu con!" />
                                                    2
                                                </label>
                                                <label class="mr-2">
                                                    <input type="checkbox" id="ck03<%#Eval("hstl_id")%>" onclick="myClick3(this.value, <%#Eval("hstl_id")%>)" value="Hôm nay tâm trạng của con chưa tốt nên các hoạt động chưa sôi nổi. Cô mong ngày mai con sẽ thật vui qua các hoạt động nhé!" />
                                                    3
                                                </label>
                                                <label class="mr-2">
                                                    <input type="checkbox" id="ck04<%#Eval("hstl_id")%>" onclick="myClick4(this.value, <%#Eval("hstl_id")%>)" value="Hôm nay con rất cố gắng với vận động “Đu xà”, con đã thực hiện tốt vận động. Cô khen con!" />
                                                    4
                                                </label>
                                                <label class="mr-2">
                                                    <input type="checkbox" id="ck05<%#Eval("hstl_id")%>" onclick="myClick5(this.value, <%#Eval("hstl_id")%>)" value="Trong giờ tạo hình con tập trung, con biết sử dụng các nguyên vật liệu khác nhau để tạo thành bức tranh rất nhiều màu sắc." />
                                                    5 
                                                </label>
                                                <label>
                                                    <input type="checkbox" id="ck06<%#Eval("hstl_id")%>" onclick="myClick6(this.value, <%#Eval("hstl_id")%>)" value="Hôm nay con thích thú khi được tham gia “hoạt động ngoài trời” Con đã giơ tay trả lời được câu hỏi của cô khi quan sát về “thời tiết” và chơi trò chơi vận động với các bạn thật vui!" />
                                                    6 
                                                </label>
                                            </div>
                                        </th>
                                        <td>
                                            <a href="javascript:void(0)" class="btn btn-primary <%#Eval("tinhtrang")%>" onclick="showDetail(<%#Eval("hstl_id")%>)">Xem nội dung</a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        <%--modal nội dung chi tiết--%>
                        <asp:Repeater ID="rpNoiDungHocSinh" runat="server">
                            <ItemTemplate>
                                <div class="modal__detail" id="modal_hocsinh_<%#Eval("hstl_id")%>">
                                    <div class="box-modal" id="box-modal_<%#Eval("hstl_id")%>">
                                        <h3 class="name">Nội dung nhận xét học tập trong ngày của bé</h3>
                                        <b>Họ tên bé: <%#Eval("hocsinh_name")%></b>
                                        <br />
                                        Nội dung:
                        <div class="form-group">
                            <textarea class="form-control" rows="5" id="txt<%#Eval("hstl_id")%>"><%#Eval("nhanxet")%></textarea>
                        </div>
                                        <a id="btnTieptuc<%#Eval("hstl_id")%>" href="javascript:void(0)" class="btn btn-danger btn__dong" style="<%=mystyle %>">Lưu</a>
                                        <a id="btnDong<%#Eval("hstl_id")%>" href="javascript:void(0)" class="btn btn-secondary btn__dong mr-2" >Đóng</a>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--<div style="display: none;">
                    <input type="text" id="txtHocSinh_id" runat="server" />
                    <input type="text" id="txtContent" runat="server" />
                </div>--%>
                        <div>
                            <a class="btn btn-primary text-white" id="btnLuuTong" style="<%=mystyle %>" onclick="DisplayLoadingIcon();myContentTong()">Lưu</a>
                        </div>
                        <div style="display: none">
                            <input type="text" id="txtDanhSachHocSinhID" runat="server" />
                            <input type="text" id="txtHocSinhDau" runat="server" />
                            <input type="text" id="txtHocSinhCuoi" runat="server" />
                            <input type="text" id="txtContentTong" runat="server" />
                            <input type="text" id="txtGhiChuTong" runat="server" />
                            <a href="#" id="btnHoanThanh" runat="server" onserverclick="btnLuuTong_ServerClick"></a>
                            <input type="text" id="txtHocSinhID" runat="server" />
                            <input type="text" id="txtContent" runat="server" />
                            <a href="#" id="btnLuu" runat="server" onserverclick="btnLuu_ServerClick"></a>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script>
        function showDetail(id) {
            let modalBg = document.querySelector("#modal_hocsinh_" + id);
            let modalDetail = document.querySelector("#box-modal_" + id);
            modalBg.classList.add("active")
            modalDetail.classList.add("active")
            document.getElementById("btnTieptuc" + id).addEventListener("click", function () {
                modalBg.classList.remove("active")
                modalDetail.classList.remove("active")
                //debugger;
                document.getElementById("<%=txtHocSinhID.ClientID%>").value = id;
                let values = document.getElementById("txt" + id).value;
                document.getElementById("<%=txtContent.ClientID%>").value = values;
                document.getElementById("<%=btnLuu.ClientID%>").click();
            });
            document.getElementById("btnDong" + id).addEventListener("click", function () {
                modalBg.classList.remove("active")
                modalDetail.classList.remove("active")
             });
        }
        function myContentTong() {
          <%--  let sodau = document.getElementById("<%=txtHocSinhDau.ClientID%>").value;
            let socuoi = document.getElementById("<%=txtHocSinhCuoi.ClientID%>").value;--%>
            let str_danhsachID = document.getElementById("<%=txtDanhSachHocSinhID.ClientID%>").value;
            let ds_hocsinh = str_danhsachID.split(';');
            //debugger;
            var noidung = [];
            //var ghichu = [];
            for (let i = 0; i < ds_hocsinh.length; i++) {
                var _noidung = (document.getElementById("txt" + ds_hocsinh[i]).value);
                //var _ghichu = (document.getElementById("txtghichu" + ds_hocsinh[i]).value);
                //if (b == '')
                //    b = a
                //else
                noidung.push(_noidung);
                //if (ghichu == '')
                //    ghichu = _ghichu;
                //else
                //ghichu.push(_ghichu);
            }
            document.getElementById("<%=txtContentTong.ClientID%>").value = noidung.join(";");
            //document.getElementById("<%=txtGhiChuTong.ClientID%>").value = ghichu.join(";");
            //console.log(ghichu);
            document.getElementById("<%=btnHoanThanh.ClientID%>").click();
        }
    </script>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>

