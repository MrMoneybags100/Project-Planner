export default function HomePage()
{
  return (
    <div>
      <h1 className="text-2xl font-bold">Welcome to Project Planner</h1>
      <p className="mt-2">Plan, manage, and track your projects with ease.</p>

      <nav className="mt-4 flex gap-4">
        <a href="/tasktree" className="text-blue-500 underline">Task Tree</a>
        <a href="/tasklist" className="text-blue-500 underline">Task List</a>
        <a href="/about" className="text-blue-500 underline">About</a>
      </nav>
    </div>
  );
}