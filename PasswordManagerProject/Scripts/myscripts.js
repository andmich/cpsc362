
    $(document).ready(function() {
        
    });

        function OpenAddPasswordModal(userId) {
            $('#UID').val(userId);
            $('#addNewPasswordOption').modal('show');
        }

        function GeneratePassword() {        

            $.ajax({
                url: '@Url.Action("GeneratePassword", "Password")',
                data: "",
                type: "POST",
                async: true,
                success: function (response) {
                    $('#newPasswordField').val(response);

                }
            });
        }

        function GetValue() {
            var myarray = new Array("item1", "item2", "item3");
            var random = myarray[Math.floor(Math.random() * myarray.length)];
            //alert(random);
            document.getElementById("message").innerHTML = random;
        }

        function copyToClipboard(idNumber) {

            var elementId = 'password-' + idNumber;
            var aux = document.createElement("input");
            aux.setAttribute("value", document.getElementById(elementId).innerHTML);
            document.body.appendChild(aux);
            aux.select();
            document.execCommand("copy");

            document.body.removeChild(aux);

}