<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module_PageWelcome.aspx.cs" Inherits="admin_page_module_function_module_VietNhatKids_module_PageWelcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link rel="icon" type="image/x-icon" href="/admin_images/logo_mamnon.png" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <style>
        .block_container {
            overflow:hidden;
            display: flex;
            position:absolute;
            width: 100%;
            height: 100%;
            align-items: center;
            justify-content: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="block_container">
            <img src="../../../admin_images/logo_mamnon.png" style="width: 100%" />
        </div>
    </form>
    <script>
        window.onclick = function () {
            window.location.href = "/login-viet-nhat-kids";
        }
    </script>
</body>
</html>
