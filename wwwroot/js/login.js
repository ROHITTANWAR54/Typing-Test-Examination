function validate() {

    var Email = document.myform.Email.value;
    if (Email == "") {
        alert("please Enter Email id");
        document.myform.Email.focus();
        return false
    }
    var Password = document.myform.Password.value;
    if (Password == "") {
        alert("please Enter Password");
        document.myform.Password.focus();
        return false
    }
    return (true);
}
