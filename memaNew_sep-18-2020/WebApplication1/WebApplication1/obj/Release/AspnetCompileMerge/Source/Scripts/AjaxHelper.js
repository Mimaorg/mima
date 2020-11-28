var AJaxHelper = {
     result:{},

    AjaxReqProcessor: function (data, async, dataType, postType, Controller, Method) {
        debugger;
        $.ajax({
            url: "/" + Controller + "/" + Method,
            dataType: dataType,
            type: postType,
            data: data,
            async: async,

            success: function (response) {
                debugger;
                console.log(response);
                AJaxHelper.result = response;
            },

            error: function (error) {
                debugger;
                console.log(error);
            }


        });

    },
    AjaxReqProcessorById: function (data, async, dataType, postType, Controller, Method, id) {
        
        $.ajax({
            url: "/" + Controller + "/" + Method + "/" + id,
            dataType: dataType,
            type: postType,
            data: data,
            async: async,

            success: function (response) {
                
                console.log(response+"from ajax helper");
                AJaxHelper.result= response;

            },

            error: function (error) {
                debugger;
                console.log(error);
            }


        });

    }

    //     $.ajax({
    //    url: `/Accounts/Login_form`,
    //    dataType: 'json',
    //type: 'post',
    //data: $('#Login_form').serialize(),
    //success: function (response) {
    //    debugger;
    //    var controller_result = response;
    //    if (controller_result == "Fail") {
    //        //console.log(controller_result)
    //        $('#Login_form')[0].reset();
    //        alert("your password or email is incorrect.")

    //    }
    //    if (controller_result == "Success") {
    //        //console.log(controller_result)
    //        window.location.href = "/My/home";
    //    }

    //},

    //error: function (error) {
    //    console.log(error);
    //}


    //})


};
