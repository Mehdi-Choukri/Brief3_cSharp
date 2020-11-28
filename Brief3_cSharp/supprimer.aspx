<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supprimer.aspx.cs" Inherits="Brief3_cSharp.supprimer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supprimer
    </title>
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
      <li class="nav-item ">
        <a class="nav-link" href="Lister.aspx">Liste des apprenants</a>
      </li>
         <li class="nav-item">
        <a class="nav-link" href="modifier.aspx">Modifier des apprenants</a>
      </li>
         <li class="nav-item active">
        <a class="nav-link" href="supprimer.aspx">Supprimer des apprenants</a>
      </li>
      
    </ul>
     
  </div>
</nav>
    <!-- Header is top-->
    <form id="form1" runat="server">
    <div>
    
    </div>
         <div id="success" runat="server" class="alert alert-success" role="alert">La suppression est effectué avec succée</div>
        <div id="fail"  runat="server" class="alert alert-danger" role="alert">L'echec de suppression </div>
         <div class="row">
         <div class="col">
                 <label for="inputsm">Identifiant Apprenant</label> 
             </div>
             <div class="col">
        <asp:DropDownList class="form-control form-control-lg" ID="cmbID" runat="server" AutoPostBack="True">
        </asp:DropDownList>
             </div>
             </div>
        <asp:Button id="btn_supprimer" runat="server" class="btn btn-lg btn-danger"  runat="server" Text="Supprimer" OnClick="btn_supprimer_Click" />
    </form>
</body>
</html>
