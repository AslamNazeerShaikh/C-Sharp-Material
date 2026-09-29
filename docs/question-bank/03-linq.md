# LINQ / IEnumerable / IQueryable

## 21. You are querying EF Core and want filtering to happen in SQL Server. When should you apply `Where()`?

- A. Before `ToList()`
- B. After `ToList()`
- C. After `AsEnumerable()`
- D. After converting to array

**Answer: A**

**Why:** Before materialization the query is still `IQueryable<T>`, so `Where` becomes part of the SQL `WHERE` clause. After `ToList()`/`AsEnumerable()` it is in-memory LINQ-to-Objects over already-fetched rows.

## 22. You execute:

```csharp
var users = db.Users.ToList();
var result = users.Where(x => x.Age > 30);
```

Where does the filtering happen?

- A. SQL Server
- B. Application memory
- C. Redis
- D. Browser

**Answer: B**

**Why:** `ToList()` executes `SELECT *`-ish immediately and loads every row. The subsequent `Where` runs in process memory — the classic "load everything, filter locally" performance bug.

## 23. You want to avoid executing a database query until enumeration. Which behavior are you relying on?

- A. Boxing
- B. Deferred execution
- C. Inheritance
- D. Reflection

**Answer: B**

**Why:** LINQ queries are lazily built expression pipelines; nothing hits the database until you enumerate (`foreach`, `ToList()`, `await ...ToListAsync()`). That lets you compose filters conditionally before paying for execution.

## 24. You have an `IQueryable<T>` and call `ToList()`. What generally happens?

- A. Query is executed
- B. Query is deleted
- C. Query becomes asynchronous automatically
- D. Query becomes a stored procedure

**Answer: A**

**Why:** `ToList()` is a terminal (greedy) operator: it forces enumeration, which translates and executes the SQL and materializes the results into a list.

## 25. You have a large database table and only need 10 records. Where should filtering/paging preferably happen?

- A. After loading everything into memory
- B. At database/query level
- C. In the controller
- D. In the UI

**Answer: B**

**Why:** Push `Where`/`Skip`/`Take` into the query so SQL returns only 10 rows. Filtering in the controller/UI after full materialization wastes database, network, and memory.

## 26. You need to check whether at least one record exists. Which is generally preferable?

- A. `Count() > 0`
- B. `Any()`
- C. `ToList().Count > 0`
- D. `First()`

**Answer: B**

**Why:** `Any()` translates to `EXISTS` and stops at the first match. `Count() > 0` counts everything (full scan/aggregation), and `ToList()` materializes all rows just to check emptiness.

## 27. You need exactly one matching record and want an exception if multiple records exist. Which LINQ method fits?

- A. `First()`
- B. `Single()`
- C. `FirstOrDefault()`
- D. `Where()`

**Answer: B**

**Why:** `Single()` asserts uniqueness: throws on zero *and* on more than one. `First()` tolerates multiples; the `*OrDefault` variants tolerate emptiness.

## 28. You need the first matching record but don't want an exception when none exists. Which should you use?

- A. `Single()`
- B. `FirstOrDefault()`
- C. `SingleOrDefault()` only
- D. `Last()`

**Answer: B**

**Why:** `FirstOrDefault()` returns the first match or `default` (null for reference types) instead of throwing. Prefer it over `SingleOrDefault()` unless you also need the uniqueness guarantee, since `Single*` must scan for a second match.
