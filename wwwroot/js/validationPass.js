function validatePassword() {
    var password = document.getElementById("password").value;
    var uppercaseRegex = new RegExp('[A-Z]');
    var specialCharRegex = new RegExp('[@!#]');

    if (password.length < 8) {
        alert("Пароль должен содержать не менее 8 символов");
        return false;
    }

    if (!uppercaseRegex.test(password)) {
        alert("Пароль должен содержать хотя бы одну заглавную букву");
        return false;
    }

    if (!specialCharRegex.test(password)) {
        alert("Пароль должен содержать хотя бы один из специальных символов: @, !, #");
        return false;
    }

    return true;
}
