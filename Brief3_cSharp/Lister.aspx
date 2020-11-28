<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lister.aspx.cs" Inherits="Brief3_cSharp.Lister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestion des apprenants</title>
      <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
   

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item ">
        <a class="nav-link" href="ajouter.aspx">Ajouter des apprenants <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item active">
        <a class="nav-link" href="Lister.aspx">Liste des apprenants</a>
      </li>
         <li class="nav-item">
        <a class="nav-link" href="modifier.aspx">Modifier des apprenants</a>
      </li>
         <li class="nav-item">
        <a class="nav-link" href="supprimer.aspx">Supprimer des apprenants</a>
      </li>
      
    </ul>
     
  </div>
</nav>
    <!-- Header is top-->
    <form id="form1" runat="server">
    <div>
    <div class="col">
        <asp:DropDownList class="form-control form-control-lg" ID="cmbSpecialite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSpecialite_SelectedIndexChanged">
        </asp:DropDownList>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Nombre d'apprenant"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="label_nbr" runat="server"></asp:Label>
        <br />
        <br />
    
    </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1171px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </form>
</body>
</html>
