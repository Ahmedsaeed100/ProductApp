var ViewUrl = "http://localhost:58628/";

// upload document
var Document = 0;
function documentImage(input) {

    Document = 0;
    var sizeKB = input.files[0].size / 1024 / 1024;
    if (sizeKB > 2) {
        alert("Please Choose Item Less Than 2 Mega");
        input.value = '';
        return;
    }

    var reader = new FileReader();
    reader.onload = function (e) {
        var extension = '';
        Document = e.target.result;
        extension = Document.split('/')[1].substring(0, 4).replace(new RegExp(';', 'g'), "");


        var block = Document.split(";");
        // Get the content type of the image
        var contentType = block[0].split(":")[1];// In this case "image/gif"
        // get the real base64 content of the file
        var realData = block[1].split(",")[1];// In this case "R0lGODlhPQBEAPeoAJosM...."
        Document = realData + "." + extension;

        // Convert it to a blob to upload
        //alert(realData)
        //IMG = b64toBlob(realData, contentType);
        //alert(IMG)
    };
    reader.readAsDataURL(input.files[0]);
}


// Saving Data
function PostMR() {
   
    var Title = $("#Title").val();
    if (Title == '') {
        alert("Please Insert Title");
        
         //bootbox.alert({
        //    title: "<p class='bootboxwarning'> Warning !! </p>",
        //    message: "Please Insert Material Request Number",
        //});
        $("#Title").addClass("dataEmpty");
        return false;
    }



    //if (Document == 0) {
    //    alert("Please Insert Image");
    //    return false;
    //}


/// End

    var data = {
        Title: $('#Title').val(),
        Description: $('#Description').val(),
        Price: $('#Price').val(),
        DOCUMENT: Document
    }

    $.ajax({
        url: ViewUrl + "AddProdct/PostProdct",
        method: "POST",
        data: JSON.stringify(data),
       // dataType: "JSON",
        contentType: "application/json",
        success: function () {
            confirmsave();
        },
        complete: function () {
            
           
                $('#responsive-modal').modal('toggle');
                Document = 0;
                $('#MoreMRTable').empty();
            
            //location.reload();
        },
        error: function (jqXHR, exception) {
            // Your error handling logic here..
            var errors = [];
            var errorsString = "";

            var response = $.parseJSON(jqXHR.responseText);
            var modelState = response.ModelState;
            for (var key in modelState) {
                if (modelState.hasOwnProperty(key)) {
                    for (var i = 0; i < modelState[key].length; i++) {

                        errorsString = (errorsString == "" ? "" : errorsString + "<br/>") + modelState[key][i];;
                        errors.push(modelState[key][i]);
                    }
                }
            }

            //DISPLAY THE LIST OF ERROR MESSAGES 
            if (errorsString != "") {
                //console.log(errorsString);
                $(window).scrollTop(0);
                bootbox.alert({
                    title: "<p class='bootboxwarning'> Warning !! </p>",
                    message: errorsString,
                });

            }
        }
    });
}





// Get Item Description and Matrial Type By IPC ID
function GetItemDescriptionAndMatTypeByIPCID() {
    $("#IPC_ID").on("change", function () {
        GetAllMatrial();

        var IPC_ID = $("#IPC_ID");
        $.ajax({
            url: ViewUrl + "Ipc/GetipcById?IPCId=" + IPC_ID.val(),
            method: "GET",
            dataType: "json",
            success: function (data) {
               // console.log(JSON.stringify(data))
                
                //alert(data.MATERIALTYPE_ID);
               
                $('#MAT_TYPE_ID').val(data.MATERIALTYPE_ID).trigger('chosen:updated');

                
                //alert(data.MATERIAL_ID);
                $('#MAT_ID').val(data.MATERIAL_ID).trigger('chosen:updated');
                WhenItemDescriptionChangedGetImages(data.MATERIAL_ID);
                WhenItemDescriptionChangedGetUnitS(data.MATERIAL_ID);
            },
            complete: function () { },
            error: function (jqXHR, exception) {
                console.log(jqXHR);
                // Your error handling logic here..
            }
        });
    });
}







// Check MR Numbers Exist
function CheckMrNumberExist() {
    $("#MR_NO").focusout(function () {
        var MrNumber = $("#MR_NO").val();
        // alert(ponumber);

        $.ajax({
            url: ViewUrl + "MR/SearchMrNumberExist?MrNumber=" + MrNumber,
            method: "GET",
            dataType: "JSON",
            contentType: "application/json",
            success: function (data) {
                // console.log(JSON.stringify(data));

                if (data.length != 0) {
                    bootbox.alert({
                        title: "<p class='bootboxwarning'> Warning !! </p>",
                        message: "MR NUMBER (<span style='color:red'>" + MrNumber + "</span>) Is Already Exist Please Change It .. ",
                    });
                    $("#MR_NO").val('');
                }
                
            },
            complete: function () {

            },
            error: function (jqXHR, exception) {
                console.log(jqXHR);
                // Your error handling logic here..
            }
        });

    });
}



