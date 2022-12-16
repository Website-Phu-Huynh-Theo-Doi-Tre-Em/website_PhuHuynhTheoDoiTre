<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Web_ThongTinCaNhan.ascx.cs" Inherits="web_usercontrol_Web_ThongTinCaNhan" %>

<style>
    .block-ttcnhan {
        background: white;
        height: 30rem;
        border-radius: 10px;
        box-shadow: 2px 3px 8px 5px #80808029;
        margin: 3% 0%;
    }

        .block-hinhdaidien img {
            width: 150px;
            height: 182px;
            object-fit: cover;
            border-radius: 20rem;
        }

    .block-thongtin {
        margin: 5%;
    }

    .thongtin {
        font-weight: 700 !important;
        color: #d12021;
        width: 63%;
        background: unset !important;
    }

    .thong-tin {
        display: flex;
        border: unset !important;
        font-weight: 600 !important;
    }

    .block-giaovien {
        background: white;
        height: auto;
        border-radius: 10px;
        margin: 3% 0%;
        box-shadow: 2px 3px 8px 5px #80808029;
    }

    .giao-vien {
        margin: 3% 0;
        display: flex;
        padding-left: 2%;
        font-weight: 600;
    }

    .bg {
        background: url('/website_PhuHuynhTheoDoiTre/images/admin.png');
    }

    @media (min-width: 500px) and (max-width:1050px) {
        .block-ttcnhan {
            height: auto;
        }

        .block-giaovien-cp {
            display: block !important;
            margin-left: 5%;
        }

        .block-giaovien {
            display: none;
        }

        .block-hinhdaidien img {
            max-width: 100%;
            min-width: 7%;
        }

        .block-ttcnhan > img {
            position: relative;
            width: 50%;
        }

        .block-ttcnhan {
            display: flex !important;
            /*margin-left: 2%;*/
        }

        .block-giaovien {
            box-shadow: none;
        }

        .giao-vien {
            /*margin: 0 3%;*/
            display: flex;
            justify-content: flex-start;
            font-weight: 600;
            flex-direction: column;
        }

        .thongtin {
            width: 60%
        }

        .block-thongtin {
            margin-bottom: 0 !important;
        }

        .content-user {
            margin-top: 2%;
        }

        .content_gv {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
        }

        .content_gvName {
            width: 38%;
        }
        .block-hinhdaidien {
    border-radius: 107px;
    width: 51%;
    background: #44403a4d;
    /* height: auto; */
    margin-top: -71.5%;
    margin-left: 23.3%;
    margin-right: 23%;
    position: absolute;
    }
    }
    .block-hinhdaidien {
    border-radius: 112px;
    width: 50%;
    background: #44403a4d;
    height: auto;
    margin-top: -71%;
    margin-left: 24%;
    margin-right: 23%;
    position: absolute;
}
</style>

<div class="block-ttcnhan col-xl-12" style="padding: 0!important;">
    <div class="col-xl-12 col-md-5 img_admin" style="padding: 0!important">
        <img  style="position: relative"src="/image/icon/admin.png" />
        <div class="block-hinhdaidien">
            <img src="/image/icon/hinh-anh-be-gai-non-la-ao-do-cuc-xinh.jpeg" />
        </div>
        <%-- <asp:Repeater runat="server" ID="rpAnh">
            <ItemTemplate>
                <div class="block-hinhdaidien">
                  <img src="<%#Eval("avartar_path") %>" />
                </div>
           </ItemTemplate>
        </asp:Repeater>--%>
    </div>
    <div class="col-xl-12 col-md-7 content-user" style="padding: 0!important">
        <span style="font-weight: 700; width: 100%; display: flex; font-size: 100%; text-transform: uppercase; justify-content: center; color: #00404e;">
            <asp:Label Text="" ID="lblHoTen" runat="server" CssClass="name" />
            
        </span>
        <div class="block-thongtin" style="line-height: 31px; margin: 5%;">
            <div class="thong-tin">
                <span class="thongtin">Lớp : </span>
                <span>
                    <asp:Label Text="" ID="lblLop" runat="server" />
                </span>
            </div>
            <div class="thong-tin">
                <div class="thongtin">Tuổi : </div>
                <span>
                    <asp:Label runat="server" ID="lblTuoi"></asp:Label>
                </span>
            </div>
            <div class="thong-tin">
                <div class="thongtin">Biệt danh : </div>
                <span>
                    <asp:Label runat="server" ID="lblBietDanh"></asp:Label>
                </span>
            </div>
            <div class="thong-tin">
                <div class="thongtin">Sở thích ở nhà : </div>
                <span>
                    <asp:Label runat="server" ID="lblSoThichONha"></asp:Label>
                </span>
            </div>
            <div class="thong-tin">
                <div class="thongtin">Sở thích tại trường : </div>
                <span>
                    <asp:Label runat="server" ID="lblSoThichOTruong"></asp:Label>
                </span>
            </div>
        </div>
        <%--rpGiaoVien khi reponsive--%>
        <div class="block-giaovien-cp" style="display: none">
             <span style="padding: 2%; font-weight: 600;">
                <asp:Label Text="" ID="lblLop2cp" runat="server" />

            </span>
            <span style="font-weight: 700 !important; color: #d12021;">Giáo viên: </span>

            <asp:Repeater runat="server" ID="rpGiaoViencp">
                <ItemTemplate>
                    <div class="giao-vien">
                        <div class="content_gv">
                            <span class="content_gvName"><%#Eval("giaovien_name") %></span>
                            <span>SDT: <%#Eval("username_phone") %></span>
                            <br />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
<%--rpGiaoVien--%>
<div class="block-giaovien">
    <span style="padding: 2%; font-weight: 600;">
        <asp:Label Text="" ID="lblLop2" runat="server" />

    </span>
    <div class="giao-vien">
        <div style="width: 20%">
            <img src="/image_PHTDT/icon/ba.png" />
        </div>
        <div style="display: flex; flex-direction: column;">
            <span>Giáo viên :Trần Thùy Trang</span>
            <span>SDT : 09234346</span>
        </div>
    </div>
    <div class="giao-vien">
        <div style="width: 20%">
            <img src="/image_PHTDT/icon/ba.png" />

        </div>
        <div style="display: flex; flex-direction: column;">
            <span>Giáo viên :Nguyễn Quốc Vinh</span>
            <span>SDT : 09234346</span>
        </div>
    </div>
    <%--<span style="padding: 2%; font-weight: 600;">
        <asp:Label Text="" ID="lblLop2" runat="server" />

    </span>
    <asp:Repeater runat="server" ID="rpGiaoVien">
        <ItemTemplate>
            <div class="giao-vien">
                <div style="width: 20%">
                    <img src="/images/ba.png" />
                </div>
                <div style="display: flex; flex-direction: column;">
                    <span>Giáo viên : <%#Eval("giaovien_name") %></span>
                    <span>SDT : <%#Eval("username_phone") %></span>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>--%>
</div>





