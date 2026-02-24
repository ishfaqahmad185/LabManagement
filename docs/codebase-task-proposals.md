# Codebase Task Proposals

## 1) Typo Fix Task
**Title:** Fix typo in navbar patient route (`Patient` -> `Patients`)

**Why:** The navbar link uses `asp-controller="Patient"`, but the actual controller class is `PatientsController`. This appears to be a typo (missing `s`) and can break navigation routing.

**Proposed acceptance criteria:**
- Update `Views/Shared/_Navbar.cshtml` to use `asp-controller="Patients"`.
- Verify the Patients nav link resolves to `/Patients` and loads successfully.

---

## 2) Bug Fix Task
**Title:** Guard against null entity deletion in POST delete handlers

**Why:** Several delete handlers call `Remove(...)` on values returned by `Find(...)` without null checks. If an item was already deleted or an invalid id is posted, this can cause a runtime exception.

**Proposed acceptance criteria:**
- Add null checks in delete-confirm actions (e.g., `PatientsController.DeleteConfirmed`, `SamplesController.DeleteConfirmed`, `InvoiceController.DeleteConfirmed`, `TestController.DeleteConfirmed`, `TestResultController.DeleteConfirmed`, `UserRoleController.DeleteConfirmed`).
- Return `NotFound()` when target entity is missing.
- Add regression tests for at least one controller showing graceful handling of missing IDs.

---

## 3) Documentation Discrepancy Task
**Title:** Align README with current implementation (authentication and API claims)

**Why:** README claims JWT authentication, Swagger API docs, admin portal, and Postman collection support, but `Program.cs` currently wires only MVC views and authorization middleware without JWT/AuthN/Swagger setup.

**Proposed acceptance criteria:**
- Update README to reflect actual currently implemented capabilities.
- Either remove API/JWT/Swagger/admin-portal claims or explicitly mark them as planned/future work.
- Ensure setup/run instructions match current project structure.

---

## 4) Test Improvement Task
**Title:** Add integration tests for critical MVC routes and POST flows

**Why:** The repository currently has no test project. Core route and controller behavior are unverified and regressions can slip in (e.g., routing typos, null-delete exceptions).

**Proposed acceptance criteria:**
- Add a test project (e.g., `LabManagement.Tests`) using `Microsoft.AspNetCore.Mvc.Testing`.
- Add at least:
  - A smoke test verifying key pages return 200 (`/`, `/Patients`, `/Test`, `/Invoice`).
  - A negative test verifying delete POST with a non-existent ID returns `NotFound` (after bug fix).
- Run tests in CI/local with `dotnet test`.
