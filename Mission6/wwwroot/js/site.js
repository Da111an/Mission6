/**
 * Dark Mode Toggle
 * Manages light/dark theme switching with persistence via localStorage.
 * Respects user's system color scheme preference if no saved preference exists.
 */
(function() {
    const darkModeToggle = document.getElementById('darkModeToggle');
    const darkModeIcon = document.getElementById('darkModeIcon');
    const htmlElement = document.documentElement;

    // Load saved theme preference or default to system preference
    const savedTheme = localStorage.getItem('theme');
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const initialTheme = savedTheme || (prefersDark ? 'dark' : 'light');

    // Initialize theme on page load
    htmlElement.setAttribute('data-bs-theme', initialTheme);
    updateIcon(initialTheme);

    // Handle toggle button clicks to switch between light and dark modes
    darkModeToggle.addEventListener('click', function() {
        const currentTheme = htmlElement.getAttribute('data-bs-theme');
        const newTheme = currentTheme === 'dark' ? 'light' : 'dark';

        htmlElement.setAttribute('data-bs-theme', newTheme);
        localStorage.setItem('theme', newTheme);
        updateIcon(newTheme);
    });

    /**
     * Updates the theme toggle button icon based on current theme.
     * @param {string} theme - The current theme ('light' or 'dark')
     */
    function updateIcon(theme) {
        darkModeIcon.textContent = theme === 'dark' ? '☀️' : '🌙';
    }
})();
