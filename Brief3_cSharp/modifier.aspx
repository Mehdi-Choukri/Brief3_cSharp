<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modifier.aspx.cs" Inherits="Brief3_cSharp.modifier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modifier</title>
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
         <li class="nav-item active">
        <a class="nav-link" href="modifier.aspx">Modifier des apprenants</a>
      </li>
         <li class="nav-item ">
        <a class="nav-link" href="supprimer.aspx">Supprimer des apprenants</a>
      </li>
      
    </ul>
     
  </div>
</nav>
    <!-- Header is top-->
    <form id="form1" runat="server">
        <div class="row">
         <div class="col">
                 <label for="inputsm">Identifiant Apprenant</label> 
             </div>
             <div class="col">
        <asp:DropDownList class="form-control form-control-lg" ID="cmbID" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbID_SelectedIndexChanged">
        </asp:DropDownList>
             </div>
             </div>
          <div id="success" runat="server" class="alert alert-success" role="alert">La modification est effectuée avec succée</div>
        <div id="fail"  runat="server" class="alert alert-danger" role="alert">L'echec de la modification</div>
         
          <div class="row">
            <div class="col">
             <label for="inputsm">Nom</label>  <input runat="server" id="input_nom" type="text" class="form-control" placeholder="Nom">
            </div>
            <div class="col">
            <label for="inputsm">Prénom</label>   <input runat="server" id="input_prenom" type="text" class="form-control" placeholder="Prenom">
            </div>
          </div>
        <div class="row">
            <div class="col">
             <label for="inputsm">Email</label>  <input id="input_email" runat="server" type="email" class="form-control" placeholder="Email">
            </div>
            <div class="col">
               <label for="inputsm">Téléphone</label> <input type="text" runat="server" id="input_telephone" class="form-control" placeholder="Telephone">
            </div>
          </div>
        <div class="row">
            <div class="col">
                <label for="inputsm">Specialité</label> 
                <asp:DropDownList class="form-control form-control-lg" ID="cmbSpecialite" runat="server"></asp:DropDownList>
              
            </div>
            <div class="col">
                 <label for="inputsm">Adresse</label> 
                <input type="text" id="input_adresse" runat="server" class="form-control" placeholder="Adresse">
            </div>
          </div>
        <!-- pays / ville -->
        <div class="row">
            <div class="col">
                <label for="inputsm">Pays</label> 
                <asp:DropDownList class="form-control form-control-lg" ID="cmbPays" runat="server" OnSelectedIndexChanged="cmbPays_SelectedIndexChanged" AutoPostBack="True" Height="55px"></asp:DropDownList>
              
            </div>
            <div class="col">
             <label for="inputsm">Ville</label> 
                <asp:DropDownList class="form-control form-control-lg" ID="cmbVille" runat="server"></asp:DropDownList>
            </div>
          </div>
       
         
          <div class="col">
                     <label for="inputsm">Date de naissance</label> 
                      <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
              <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
              <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
              <OtherMonthDayStyle ForeColor="#999999" />
              <SelectedDayStyle BackColor="#333399" ForeColor="White" />
              <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
              <TodayDayStyle BackColor="#CCCCCC" />
          </asp:Calendar>
                    </div>
     
         
       
         
 
     
          <asp:Button id="btn_ajouter" runat="server" class="btn btn-lg btn-primary" OnClick="Button1_Click" Text="Modifier" />
         
     
    </form>
</body>
</html>
