let buddy = window.buddy || {};

(function () {
    if (!buddy) {
        return;
    }

    buddy.localization = buddy.localization || {};

    buddy.localization.ping = function () {
        console.log("Ping from buddy-localization module.")
    }
})(); 