# Collections

## 65. You need fast lookup by unique key. Which collection is generally appropriate?

- A. `Dictionary<TKey,TValue>`
- B. `List<T>`
- C. `Queue<T>`
- D. `Stack<T>`

**Answer: A**

**Why:** `Dictionary` is a hash table: average O(1) lookup by key. `List<T>` lookup is O(n) scan. (Keys must be unique and have a sound `GetHashCode`/`Equals`.)

## 66. You need FIFO behavior. Which collection?

- A. `Stack<T>`
- B. `Queue<T>`
- C. `Dictionary<T>`
- D. `HashSet<T>`

**Answer: B**

**Why:** `Queue<T>` (`Enqueue`/`Dequeue`) is first-in-first-out — work queues, BFS, message processing. `Stack<T>` is the opposite order (LIFO).

## 67. You need LIFO behavior. Which collection?

- A. `Queue<T>`
- B. `Stack<T>`
- C. `Dictionary<T>`
- D. `List<T>`

**Answer: B**

**Why:** `Stack<T>` (`Push`/`Pop`) is last-in-first-out — undo buffers, DFS, expression evaluation, call-stack modeling.

## 68. You need unique values without duplicates. Which collection?

- A. `List<T>`
- B. `HashSet<T>`
- C. `Queue<T>`
- D. `Array`

**Answer: B**

**Why:** `HashSet<T>` enforces uniqueness with O(1) add/contains and set operations (Union/Intersect/Except). A `List<T>` happily stores duplicates and needs O(n) scans to check membership.

## 69. You need thread-safe concurrent key/value access. Which might be appropriate?

- A. `Dictionary<TKey,TValue>`
- B. `ConcurrentDictionary<TKey,TValue>`
- C. `List<T>`
- D. `HashSet<T>`

**Answer: B**

**Why:** Plain `Dictionary` is not thread-safe for concurrent writes (risk of corruption/exceptions). `ConcurrentDictionary` uses fine-grained locking/lock-free reads plus atomic helpers (`GetOrAdd`, `AddOrUpdate`) designed for multi-threaded access.
