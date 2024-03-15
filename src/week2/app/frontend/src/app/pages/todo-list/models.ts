export type TodoListItem = {
  id: string;
  description: string;
  completed: boolean;
  dueDate?: string;
  priority?: 'Low' | 'High';
};
