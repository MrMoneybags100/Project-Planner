import "./globals.css";
import Image from "next/image";

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body className="flex flex-col min-h-screen">
        {/* Header */}
        <header className="flex justify-between items-center px-6 py-4 bg-yellow-100 shadow-md border-b-4 border-red-600">
          <a href="/" className="flex items-center gap-3">
            <Image
              src="/Logo.png"
              alt="Project Planner Logo"
              width={60}
              height={60}
              priority
            />
            <span className="text-2xl font-bold text-red-700">Project Planner</span>
          </a>
          <nav className="flex gap-6">
            <a href="/tasktree" className="text-green-800 font-medium hover:text-red-600 transition">
              Task Tree
            </a>
            <a href="/tasklist" className="text-green-800 font-medium hover:text-red-600 transition">
              Task List
            </a>
            <a href="/about" className="text-green-800 font-medium hover:text-red-600 transition">
              About
            </a>
          </nav>
        </header>

        {/* Main content */}
        <main className="flex-grow p-6">{children}</main>

        {/* Footer */}
        <footer className="bg-green-900 text-yellow-100 py-6 border-t-4 border-red-600 text-center">
          <p>© {new Date().getFullYear()} Project Planner.</p>
          <p className="text-sm">Made with ❤️ and 🎧</p>
        </footer>
      </body>
    </html>
  );
}
