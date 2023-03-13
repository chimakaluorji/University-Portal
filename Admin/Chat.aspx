<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="Chat.aspx.vb" Inherits="Admin_Chat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- Toastr style -->
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="js/plugins/gritter/jquery.gritter.css" rel="stylesheet">

    <link href="css/plugins/dataTables/datatables.min.css" rel="stylesheet">

 
    <link href="css/solidrock.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">

    <link href="css/plugins/chosen/chosen.css" rel="stylesheet">

    <link href="css/plugins/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet">

    <link href="css/plugins/cropper/cropper.min.css" rel="stylesheet">

    <link href="css/plugins/switchery/switchery.css" rel="stylesheet">

    <link href="css/plugins/jasny/jasny-bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/nouslider/jquery.nouislider.css" rel="stylesheet">

    <link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet">

    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.css" rel="stylesheet">
    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css" rel="stylesheet">

    <link href="css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">

    <link href="css/plugins/clockpicker/clockpicker.css" rel="stylesheet">

    <link href="css/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet">

    <link href="css/plugins/select2/select2.min.css" rel="stylesheet">

    <link href="css/plugins/touchspin/jquery.bootstrap-touchspin.min.css" rel="stylesheet">


     <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
   <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet"> 

    <div class="wrapper wrapper-content animated fadeInRight">
    <div class="row">
        <div class="col-lg-12">

                <div class="ibox chat-view">

                    <div class="ibox-title">
                        <small class="pull-right text-muted">
                            <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                            <% lblTime.Text = "You"%>
                            Last message:  Mon Jan 26 2015 - 18:39:23
                        </small>
                         Chat Room Panel
                        <div class="alert alert-danger" id="danger" style="display:none;">
                                   You must select a student to continue chatting.
                         </div>
                    </div>


                    <div class="ibox-content">

                        <div class="row">

                            <div class="col-md-9 ">
                                <div class="chat-discussion" id="chat-discussion">

                                    <%--<div class="chat-message left">
                                        <img class="message-avatar" src="img/a1.jpg" alt="" >
                                        <div class="message">
                                            <a class="message-author" href="#"> Michael Smith </a>
											<span class="message-date"> Mon Jan 26 2015 - 18:39:23 </span>
                                            <span class="message-content">
											Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="chat-message right">
                                        <img class="message-avatar" src="img/a4.jpg" alt="" >
                                        <div class="message">
                                            <a class="message-author" href="#"> Karl Jordan </a>
                                            <span class="message-date">  Fri Jan 25 2015 - 11:12:36 </span>
                                            <span class="message-content">
											Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="chat-message right">
                                        <img class="message-avatar" src="img/a2.jpg" alt="" >
                                        <div class="message">
                                            <a class="message-author" href="#"> Michael Smith </a>
                                            <span class="message-date">  Fri Jan 25 2015 - 11:12:36 </span>
                                            <span class="message-content">
											There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="chat-message left">
                                        <img class="message-avatar" src="img/a5.jpg" alt="" >
                                        <div class="message">
                                            <a class="message-author" href="#"> Alice Jordan </a>
                                            <span class="message-date">  Fri Jan 25 2015 - 11:12:36 </span>
                                            <span class="message-content">
											All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet.
                                                It uses a dictionary of over 200 Latin words.
                                            </span>
                                        </div>
                                    </div>
                                    <div class="chat-message right">
                                        <img class="message-avatar" src="img/a6.jpg" alt="" >
                                        <div class="message">
                                            <a class="message-author" href="#"> Mark Smith </a>
                                            <span class="message-date">  Fri Jan 25 2015 - 11:12:36 </span>
                                            <span class="message-content">
											All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet.
                                                It uses a dictionary of over 200 Latin words.
                                            </span>
                                        </div>
                                    </div>--%>

                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="chat-users">


                                    <div class="users-list" id="users-list">
                                        <%--<div class="chat-user">
                                            <img class="chat-avatar" src="img/a4.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Karl Jordan</a>
                                            </div>
                                        </div>
                                        <div class="chat-user">
                                            <img class="chat-avatar" src="img/a1.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Monica Smith</a>
                                            </div>
                                        </div>--%>
                                        <%--<div class="chat-user">
                                            <span class="pull-right label label-primary">Online</span>
                                            <img class="chat-avatar" src="img/a2.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Michael Smith</a>
                                            </div>
                                        </div>--%>
                                        <%--<div class="chat-user">
                                            <span class="pull-right label label-primary">Online</span>
                                            <img class="chat-avatar" src="img/a3.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Janet Smith</a>
                                            </div>
                                        </div>
                                        <div class="chat-user">
                                            <img class="chat-avatar" src="img/a5.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Alice Smith</a>
                                            </div>
                                        </div>
                                        <div class="chat-user">
                                            <img class="chat-avatar" src="img/a6.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Monica Cale</a>
                                            </div>
                                        </div>
                                        <div class="chat-user">
                                            <img class="chat-avatar" src="img/a2.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Mark Jordan</a>
                                            </div>
                                        </div>
                                        <div class="chat-user">
                                            <span class="pull-right label label-primary">Online</span>
                                            <img class="chat-avatar" src="img/a3.jpg" alt="" >
                                            <div class="chat-user-name">
                                                <a href="#">Janet Smith</a>
                                            </div>
                                        </div>--%>


                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="chat-message-form">

                                    <div class="form-group">

                                        <textarea class="form-control message-input" name="message" placeholder="Enter message text" id="txtMsgBox"></textarea>
                                    </div>

                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="ibox-title">
                        <small class="pull-right text-muted">
                            <input type="button" id="btnSend" value="Send" class="btn btn-primary" />
                            <%--<asp:Button ID="Button1" runat="server" Text="Button" />
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
                        </small>
                    </div>

                </div>
        </div>

    </div>


</div>

<%--New Implementation of jquery button submit--%>
<script type="text/javascript" src="js/jquery-1.8.2.js"></script>
<script type="text/javascript">

    $(function () {

        //Page loading all Chat
        load_all_chat();

        
        //load_All_Student_Online();


        //Sending Message
        $('#btnSend').click(function () {
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            //var regno = getUrlParameter('regno');
            var username = '<%=Request.QueryString("Username")%>';
            var msg = $('#txtMsgBox').val();

            var regNumber = '';
            regNumber = '<%=Request.QueryString("regno")%>';

            <%
    Dim Encrpty As EncryptionUtil = New EncryptionUtil
    
    Dim UserDal As LoginDAL = New LoginDAL
    Dim UserData As LoginData = New LoginData

    Dim UserNames As String = Request.QueryString("Username")
    Dim DecryptUser As String = Encrpty.Decrypt(UserNames)
            %>

            var newUserName = '<%=DecryptUser%>';

            if (regNumber == '') {
                $('#danger').show();
                return false
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Chat.aspx/InsertAminChat",
                data: "{'Eusername':'" + username + "','Eregno':'" + regNumber + "','Emsg':'" + msg + "','Edate':'" + date + "','Etime':'" + time + "'}",
                dataType: "json",
                success: function (data) {
                    var leftMsg = "";
                    var rightMsg = "";
                    var photo = data.d[0].UserPhotoUrl;

                    var newArrayPhoto = photo.split("/");
                    var newPhoto = "../" + newArrayPhoto[1] + '/' + newArrayPhoto[2];

                    var username = data.d[0].UserName;

                    leftMsg = "<div class='chat-message right' id='left'> <img class='message-avatar' src='" + newPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + newUserName + " </a><span class='message-date'>" + time + "</span><span class='message-content'>" + msg + "</span></div></div>";

                    var div = $(leftMsg + rightMsg);
                    $("#chat-discussion").append(div);

                    $('#txtMsgBox').val('');


                    //Ensuring the scroll bar is at the bottom
                    $("#chat-discussion").animate({ scrollTop: $('#chat-discussion').prop("scrollHeight") }, 1000);
                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            });
            //Sending Message Ends here

        });

        //Pressing Enter Key
        $('#txtMsgBox').keypress(function (e) {
            if (e.which == 13) {
                $("#btnSend").click();
                e.preventDefault();
            }
        });
        //End of Pressing Enter Key


        //Knowing when a message is read
        jQuery('#txtMsgBox').on('input', function () {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var regno = '<%=Request.QueryString("regno")%>';
            var username = '<%=Request.QueryString("Username")%>';

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Chat.aspx/ReadMessage",
                data: "{'Eusername':'" + username + "','Eregno':'" + regno + "','Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                },
                error: function (result) {
                   // alert('Something went wrong.');
                }
            });
        });


        setInterval(load_All_Student_Online, 1000);

        function load_All_Student_Online() {
            //Loading Student Online
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Chat.aspx/GetStudentOnline",
                data: "{}",
                dataType: "json",
                success: function (data) {

                    var chatPanel = "";
                    var photoUrl = "";

                    $("#users-list").empty();

                    for (var i = 0; i < data.d.length; i++) {
                        var photo = data.d[i].PhotoUrl;

                        var newArrayPhoto = photo.split("/");
                        var newPhoto = "../" + newArrayPhoto[1] + '/' + newArrayPhoto[2];
                        msgCount = data.d[i].MsgCount;

                        chatPanel = "<div class='chat-user'><span class='pull-right label label-primary'> " + msgCount  + " </span><img class='chat-avatar' src='" + newPhoto + "' alt='' ><div class='chat-user-name'> <a href='Chat.aspx?Username=<%=Request.QueryString("Username")%>&regno=" + data.d[i].RegNumber + "'>" + data.d[i].StudentName + "</a></div></div>";

                        $("#users-list").append(chatPanel);
                    }

                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            }); //End of Loading student online
        }


        setInterval(student_chat, 1000);
        //Creating a reload function
        var ChatID = 0;

        function student_chat() {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var regNumber = '';
            regNumber = '<%=Request.QueryString("regno")%>';

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Chat.aspx/GetStudentChat",
                data: "{'Eregno':'" + regNumber + "','Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                    var leftMsg = "";
                    var rightMsg = "";
                    var dbChatID = 0;

                    //Handling audio
                    var audiot = new Audio("../ChatSound/sound.mp3");

                    dbChatID = data.d[0].ChatID;
                    var photo = data.d[0].StudentPhotoUrl;

                    var newArrayPhoto = photo.split("/");
                    var newPhoto = "../" + newArrayPhoto[1] + '/' + newArrayPhoto[2];

                    if (dbChatID > ChatID) {
                        leftMsg = "<div class='chat-message left' id='left'> <img class='message-avatar' src='" + newPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + data.d[0].StudentName + " </a><span class='message-date'>" + data.d[0].StudentTime + "</span><span class='message-content'>" + data.d[0].StudentMsg + "</span></div></div>";
                        ChatID = dbChatID

                        audiot.play();
                        //audiot.pause();


                    } //End if statement for checking if message was sent


                    var div = $(leftMsg);
                    $("#chat-discussion").append(div);

                    $("#chat-discussion").animate({ scrollTop: $('#chat-discussion').prop("scrollHeight") }, 1000);
                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            });
            //Sending Message Ends here
        }


        //Creating a reload function
        function load_all_chat() {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var regno = '<%=Request.QueryString("regno")%>';
            var username = '<%=Request.QueryString("Username")%>';

           

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Chat.aspx/GetAdminChat",
                data: "{'Eusername':'" + username + "','Eregno':'" + regno + "','Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                    var checkUserMsg = "";
                    var checkStudentMsg = "";
                    var leftMsg = "";
                    var rightMsg = "";

                    //alert(data.d[1].StudentMsg);

                    for (var i = 0; i < data.d.length; i++) {
                        checkUserMsg = data.d[i].UserMsg;
                        checkStudentMsg = data.d[i].StudentMsg;
                        userPhoto = data.d[i].UserPhotoUrl;
                        studentPhoto = data.d[i].StudentPhotoUrl;

                        var newArrayuserPhoto = userPhoto.split("/");
                        var newuserPhoto = "../" + newArrayuserPhoto[1] + '/' + newArrayuserPhoto[2];

                        var newArraystudentPhoto = studentPhoto.split("/");
                        var newstudentPhoto = "../" + newArraystudentPhoto[1] + '/' + newArraystudentPhoto[2];

                        if (checkStudentMsg != '') {
                            leftMsg = "<div class='chat-message left' id='left'> <img class='message-avatar' src='" + newstudentPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + data.d[i].StudentName + " </a><span class='message-date'>" + data.d[i].StudentTime + "</span><span class='message-content'>" + data.d[i].StudentMsg + "</span></div></div>";
                        }

                        if (checkUserMsg != '') {
                            rightMsg = "<div class='chat-message right' id='right'> <img class='message-avatar' src='" + newuserPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + data.d[i].UserName + " </a><span class='message-date'>" + data.d[i].UserTime + "</span><span class='message-content'>" + data.d[i].UserMsg + "</span></div></div>";
                        }

                        var div = $(leftMsg + rightMsg);
                        $("#chat-discussion").append(div);
                    }

                    //Sending Message Ends here
                    $('#chat-discussion').animate({ scrollTop: $(document).height() }, 1500);

                },
                error: function (result) {
                   // alert('Something went wrong.');
                }
            });// closing ajax
            
        }
        //End of function auto load

    });//End sending message

</script>
<!-- Mainly scripts -->
<script src="js/jquery-2.1.1.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
<script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

<!-- Custom and plugin javascript -->
<script src="js/inspinia.js"></script>
<script src="js/plugins/pace/pace.min.js"></script>

<script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

</asp:Content>