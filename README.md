### What is this project?
- This is a mini cash withdraw screen for a generic ATM machine. You can type an amount of cash, and ATM backend will calculate a optimal amount of banknotes from its reserves to deposit to you.
- The cash dispenser algorithm works with dynamic programming methods, focusing on coin change (knapsack variant) problem with limited coins constraint.
- The backend can be improved further by adding cash deposit and other functionalities.

### Tech Stack
- C# Dot Net for backend, React JS for frontend. Used Vite for build scripting, and Visual Studio for development.
- Used Github Copilot as helper in development, mostly for styling and bugfixing.
- This is a learning project, please don't try to use it for your own ATM, it wouldn't be that secure :)

### TODO
- Testing should be added.
- Frontend is a bit primitive for my taste, we could leverage React more by seperating divs into react components, and combining them in another page.
- There should be a request response handler/utilization service and a middleware for rerouting in the backend services too.
