const DashboardUI = {
    init: function () {
        this.setGreeting();
        this.animateBars();
    },

    setGreeting: function () {
        const hour = new Date().getHours();
        const greetingEl = document.getElementById('dashboard-greeting');
        if (!greetingEl) return;

        let message = "Consistent action is the bridge between goals and accomplishment.";
        if (hour < 12) message = "The morning is for clarity. Define your priorities and set the pace for the day.";
        else if (hour < 18) message = "Maintain your momentum. Every task completed now creates a smoother path for tomorrow.";
        else message = "The day is done. Review your progress, clear your mind, and prepare for a fresh start.";

        greetingEl.innerText = message;
    },

    animateBars: function () {
        // Triggered by CSS transition
    }
};

document.addEventListener("DOMContentLoaded", () => DashboardUI.init());