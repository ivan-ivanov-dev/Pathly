const DashboardUI = {
    init: function () {
        this.setGreeting();
        this.animateBars();
    },

    setGreeting: function () {
        const hour = new Date().getHours();
        const greetingEl = document.getElementById('dashboard-greeting');
        if (!greetingEl) return;

        let message = "";
        // Morning
        if (hour >= 5 && hour < 12) {
            message = "Good morning! The path is clear. Focus on your high-priority tasks first.";
        }
        // Afternoon
        else if (hour >= 12 && hour < 18) {
            message = "Good afternoon. Keep that momentum steady; your future self will thank you.";
        }
        // Evening
        else if (hour >= 18 && hour < 22) {
            message = "Evening check-in. Wrap up the loose ends and prepare for a restful night.";
        }
        // Night
        else {
            message = "Rest is part of the strategy. Recharge now to conquer tomorrow.";
        }

        greetingEl.innerText = message;
    },

    animateBars: function () {
        // Triggered by CSS transition
    }
};

document.addEventListener("DOMContentLoaded", () => DashboardUI.init());