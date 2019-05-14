function warningMessage(params) {

    for (i = 0; i < params.length; i++) {
        if (params[i] < 5) {
            window.confirm("En av verdiene er for lave!");
        }
    }
}