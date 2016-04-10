<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Web.DecryptNetScalerCookie.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta content='width=device-width, initial-scale=1' name='viewport' />
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
  <meta name="viewport" content="width=1080" />
  <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
  <title>NetScaler Cookie decrypter</title>
  <style type="text/css">
    @font-face{font-weight:400;font-style:normal;font-family:icomoon;src:url(./fonts/icomoon/icomoon.eot?-9heso);src:url(./fonts/icomoon/icomoon.eot?#iefix-9heso) format('embedded-opentype'),url(./fonts/icomoon/icomoon.woff?-9heso) format('woff'),url(./fonts/icomoon/icomoon.ttf?-9heso) format('truetype'),url(./fonts/icomoon/icomoon.svg?-9heso#icomoon) format('svg')}
    #sp-content,body{background-position:top left}#grid,#sp-footer,#sp-footer-menu,#sp-footer-menu .footer-heading,.h1,h1{font-family:"Open Sans",Arial,"Helvetica Neue",Helvetica,sans-serif}#sp-content,#sp-footer,#sp-header{border-radius:0;background-attachment:scroll}#sp-content,#sp-footer,#sp-header,body{background-repeat:repeat;background-size:auto}#grid,.h1,.submit:after,h1{font-weight:400;font-style:normal}#wrapper,ol,ul{overflow:hidden}.h1,h1,img{text-decoration:none}#grid,.h1,h1{text-shadow:none}#wrapper,.block{position:relative}#grid:after,.block:after,body:after{clear:both}body{width:100%}body:after,body:before{content:"";display:table}.grid_12,.grid_24{display:inline;float:left;min-height:5px}.grid_24{width:940px;margin:0}.grid_12{width:455px;margin:0 15px}.column.alpha{margin-left:0}.column.omega{margin-right:0}body{margin:0;padding:0;height:100%;background-color:#202020;background-attachment:fixed;-webkit-text-size-adjust:none}.text-link,a:link,a:visited{color:#ff523b;text-decoration:none}a:hover{color:#ff523b}img{border-style:none}#wrapper{margin:0 auto;min-height:100%}#grid{color:#000;font-size:13px;line-height:1.7em;width:940px;margin:0 auto;min-height:400px;display:block;float:none}#grid:after,#grid:before,.block:after,.block:before{content:"";display:table}.column:first-child{margin-left:0}.column:last-child{margin-right:0}.h1,h1{color:#ff523b;font-size:24px;line-height:2em;text-transform:none;letter-spacing:-.04em;margin:0}#sp-content,#sp-footer-menu{margin-left:auto;margin-right:auto}.block{width:100%;margin-bottom:5px;padding-top:5px;padding-bottom:5px}.block.heading{margin-bottom:0;padding:0}#sp-footer,#sp-header{background-position:top center;margin:0 auto}#sp-content,#sp-header{width:1080px}#sp-header{height:325px;background-color:#ff523b}#sp-header #snappages-header-canvas{position:relative;width:1080px;margin-right:auto;margin-left:auto}#sp-header .snappages-header-element{padding:10px;line-height:1em;display:inline-block;position:absolute;cursor:default;-webkit-touch-callout:none;-webkit-user-select:none;-moz-user-select:none;-ms-user-select:none;user-select:none}#sp-content{min-height:400px;padding-top:25px;padding-bottom:40px;background-color:#FFF}#sp-footer,#sp-footer-menu{font-size:13px;line-height:1.5em;text-shadow:none}#sp-footer,#sp-footer-menu,#sp-footer-menu .footer-heading{font-weight:400;font-style:normal}#sp-footer{width:1080px;min-height:200px;padding-bottom:20px;color:#000;background-color:#c8c8c8}#sp-footer-menu{width:940px;min-height:25px;padding-top:30px;color:#fff}#sp-footer-menu .footer-heading{color:#FFF;font-size:16px;line-height:2.4em;text-decoration:none;text-transform:uppercase;letter-spacing:.04em}.cookie input,.submit{display:block;border:none}.submit,.submit:after{position:absolute;top:0}.cookie{width:550px;position:absolute}.cookie input{margin:.3em 0 0;width:100%;padding:.5em 3em .5em .7em;color:rgba(0,0,0,.8);font-size:1em;height:2em}.cookie input:focus{outline:auto}.submit{right:-3.3em;padding:0;height:3em;width:3em;background:0 0;color:rgba(0,0,0,.4);text-align:center;opacity:1;z-index:100;cursor:pointer}.submit:hover{color:rgba(0,0,0,.5)}.submit:after{left:0;width:100%;height:100%;content:"\e600";text-transform:none;font-variant:normal;font-family:icomoon;line-height:2em;speak:none;font-size:25px}
    .modal-box,.modal-overlay,a.close{position:absolute}.btn,a.close{text-decoration:none}.modal-box{display:none;z-index:1000;width:98%;background:#fff;border-radius:4px;box-shadow:0 3px 9px rgba(0,0,0,.5);border:1px solid rgba(0,0,0,.1);background-clip:padding-box}@media (min-width:32em){.modal-box{width:600px}}.modal-box .modal-header,.modal-box header{padding:1.25em 1.5em}.modal-box .modal-header h3,.modal-box .modal-header h4,.modal-box header h3,.modal-box header h4{margin:0}.modal-box .modal-body{padding:2em 1.5em}.modal-box .modal-footer,.modal-box footer{padding:1em;text-align:right}.modal-overlay{opacity:0;filter:alpha(opacity=0);top:0;left:0;z-index:900;width:100%;height:100%;background:rgba(0,0,0,.75)!important}.btn,.btn:hover{background-color:#fff}a.close{line-height:1;font-size:1.5em;top:5%;right:2%;color:#bbb}a.close:hover{color:#222;-webkit-transition:color 1s ease;-moz-transition:color 1s ease;transition:color 1s ease}.btn{padding:.75em 1.5em;margin-left:50px;width:250px;border:1px solid #bbb;color:#333;display:inline;-webkit-transition:background-color 1s ease;-moz-transition:background-color 1s ease;transition:background-color 1s ease}.btn:hover{color:#ff523b!important;-webkit-transition:background-color 1s ease;-moz-transition:background-color 1s ease;transition:background-color 1s ease}.first{margin:0}.btn-small{padding:.75em 1em;font-size:.8em}.v-center{width:100%;display:table;position:relative;text-align:center}.v-center>div{display:table-cell;vertical-align:middle;position:relative}.btn-default{font-family:'Open Sans';color:#fff!important;font-size:20px;font-weight:600;font-style:normal;letter-spacing:.1em;border-radius:0;background-color:#ff523b}

  </style>
  <link href='https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,800' rel='stylesheet' type='text/css' />
</head>
<body>
  <div id="inspector" class="modal-box">
    <header>
      <a href="#" class="js-modal-close close">×</a>
    </header>
    <div class="v-center">
      <div class="modal-body">
        <a class="js-modal-close btn btn-default first" href="./files/Ext.Fiddler2.NetScalerInspector.dll">Fiddler 2</a>
        <a class="js-modal-close btn btn-default" href="./files/Ext.Fiddler4.NetScalerInspector.dll">Fiddler 4</a>
      </div>
    </div>
    <footer></footer>
  </div>
  <div id="netscalermenu" class="modal-box">
    <header>
      <a href="#" class="js-modal-close close">×</a>
    </header>
    <div class="v-center">
      <div class="modal-body">
        <a class="js-modal-close btn btn-default first" href="./files/Ext.Fiddler2.NetScalerMenu.dll">Fiddler 2</a>
        <a class="js-modal-close btn btn-default" href="./files/Ext.Fiddler4.NetScalerMenu.dll">Fiddler 4</a>
      </div>
    </div>
    <footer></footer>
  </div>

  <div id="wrapper">
    <div id="sp-header">
      <div id="snappages-header-canvas">
        <div class="snappages-header-element" style="font-family: 'Open Sans'; color: #ffffff; font-size: 60px; font-weight: 300; font-style: normal; letter-spacing: 0.1em; top: 100px; left: 55px; border-radius: 0px; background-color: transparent;">NetScaler Cookie</div>
        <div class="snappages-header-element" style="font-family: 'Open Sans'; color: #ffffff; font-size: 60px; font-weight: 600; font-style: normal; letter-spacing: 0.13em; top: 155px; left: 60px; border-radius: 0px; background-color: transparent;">Decrypter</div>

        <div class="snappages-header-element" style="font-family: 'Open Sans'; color: #ffffff; font-size: 25px; font-weight: 400; font-style: normal; letter-spacing: 0.1em; top: 275px; left: 55px; border-radius: 0px; background-color: transparent;">Do you use Fiddler? Decrypt it right there!!!</div>
        <div class="snappages-header-element" style="font-family: 'Open Sans'; color: #ffffff; font-size: 13px; font-weight: 600; font-style: normal; letter-spacing: 0.1em; top: 295px; left: 825px; border-radius: 0px; background-color: transparent;">
          I am in hurry.
          <a style="font-family:'Open Sans'; color: #ffffff; text-decoration: underline; font-weight:900;" href="#onetime">Decrypt it here</a>
        </div>

      </div>
    </div>
    <div id="sp-content">
      <div id="content" data-layout="twocolumn" data-index="9">
        <div id="grid" class="container_24">
          <div class="column container grid_24 alpha omega">
            <div class="column grid_12 alpha">
              <div class="block heading" data-type="heading" data-title="heading" data-id="0">
                <div class="h1" style="text-align: left;">Fiddler Inspector Extension</div>
              </div>
              <div class="block text" data-type="text" data-title="text" data-id="1">
                <div style="text-align: justify;">
                  This extension can identify netscaler cookie and decrypt it right there in fiddler window for easy access. This may help you identify the server which is not playing nice. Give them yellow card or red card, its all up to you.
                  <ol>
                    <li>
                      <a class="js-open-modal" href="#" data-modal-id="inspector"><b>Click</b></a> to download the fiddler extenstion for netscaler cookie decryption.
                      <b>Ext.Fiddler.NetScalerInspector.dll</b>
                    </li>
                    <li>Open your fiddler install directory.&nbsp; <b>C:\Program Files (x86)\Fiddler2</b>
                    </li>
                    <li>Drop the downloaded <b>dll</b> in step in 1 to
                      <b>Inspectors</b> directory.
                    </li>
                    <li>
                      <b>Restart</b> Fiddler.
                    </li>
                  </ol>
                </div>
              </div>
              <img src="./files/Netscaler Cookie Inspector.png" />
            </div>
            <div class="column grid_12 omega">
              <div class="block heading" data-type="heading" data-title="heading" data-id="3">
                <div class="h1" style="text-align: left;">Server Name Lookup (Optional)</div>
              </div>
              <div class="block text" data-type="text" data-title="text" data-id="4">
                <div style="text-align: justify;">
                  Are you using fiddler within the firewall? Can you ping server ip from that machine? If your answer is YES, this extension can help you lookup the server name. &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <ol>
                    <li>
                      <a class="js-open-modal" href="#" data-modal-id="netscalermenu"><b>Click</b></a> to download the server name lookup fiddler extenstion dll. <b>Ext.Fiddler.NetScalerMenu.dll</b>
                    </li>
                    <li>Open your fiddler install directory. <b>C:\Program Files (x86)\Fiddler2</b>
                    </li>
                    <li>Drop the downloaded <b>dll</b> in step in 1 to <b>Scripts</b> directory.
                    </li>
                    <li>
                      <b>Restart</b> Fiddler.
                    </li>
                  </ol>
                </div>
              </div>
              <img src="./files/Netscaler Cookie ServerNameLookup.png" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div id="sp-footer">
      <div id="sp-footer-menu">
        <form id="form1" runat="server">
          <div id="onetime" class="footer-heading">Decrypt Netscaler Cookie</div>
          <div class="cookie">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <button id="button1" type="submit" runat="server" class="submit"></button>
          </div>
          <div style="height: 75px;"></div>
          <div>
            <asp:Label ID="Label1" runat="server" Width="100px" Text="Server Group:"></asp:Label>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
          </div>
          <div>
            <asp:Label ID="Label2" runat="server" Width="100px" Text="Server IP:"></asp:Label>
            <asp:Literal ID="Literal2" runat="server"></asp:Literal>
          </div>
          <div>
            <asp:Label ID="Label3" runat="server" Width="100px" Text="Server Port:"></asp:Label>
            <asp:Literal ID="Literal3" runat="server"></asp:Literal>
          </div>
        </form>
      </div>
    </div>
  </div>

  <script src="http://code.jquery.com/jquery-1.12.0.min.js"></script>
  <script>
    $(function () {

      var appendthis = ("<div class='modal-overlay js-modal-close'></div>");

      $('a[data-modal-id]').click(function (e) {
        e.preventDefault();
        $("body").append(appendthis);
        $(".modal-overlay").fadeTo(500, 0.7);
        var modalBox = $(this).attr('data-modal-id');
        $('#' + modalBox).fadeIn($(this).data());
      });


      $(".js-modal-close, .modal-overlay").click(function () {
        $(".modal-box, .modal-overlay").fadeOut(500, function () {
          $(".modal-overlay").remove();
        });

      });

      $(window).resize(function () {
        $(".modal-box").css({
          top: ($(window).height() - $(".modal-box").outerHeight()) / 2,
          left: ($(window).width() - $(".modal-box").outerWidth()) / 2
        });
      });

      $(window).resize();

    });
  </script>
</body>
</html>
