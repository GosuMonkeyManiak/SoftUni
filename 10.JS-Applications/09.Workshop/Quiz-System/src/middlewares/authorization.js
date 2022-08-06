function authorization(ctx, next) {
    let userData = ctx.getUserData();

    if (userData != null) {
        next();
    } else {
        ctx.redirect('/login');
    }
}

export {
    authorization
}