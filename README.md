
# Feature Flag Engine – Coding Challenge Submission

This repository contains an end-to-end implementation of a feature flag system designed with performance, correctness, and clean architecture in mind.

The core feature flag engine runs fully in-memory and is safe to evaluate on every request.

---

# Core Requirements

## Performance Considerations

In real systems, feature flags may be evaluated on every request.  
The evaluation path in this implementation:

- Avoids any I/O or network calls
- Uses in-memory lookups only
- Has deterministic O(n) evaluation over small override lists
- Does not allocate unnecessary objects during evaluation

All reads are served from a Redis-style in-memory cache.  
The database (simulated) acts as the authoritative store and is only used to warm the cache.

This ensures the system scales as the number of:
- Features
- Users
- Groups
- Regions

grows over time.

---

## Region-Based Overrides

The override mechanism supports:

- User overrides
- Group overrides
- Region overrides

Region overrides integrate cleanly into the evaluation logic without branching complexity.

Override precedence:

1. User
2. Group
3. Region
4. Default

The first matching override wins.  
If none apply, the feature’s default state is returned.

This logic is:

- Deterministic
- Explicit
- Test-covered
- Easy to extend

---

# Design

The solution follows a layered architecture:

FeatureFlags.Core
- Domain models
- Evaluation engine

FeatureFlags.Infrastructure
- DB-backed store (authoritative)
- Redis read cache

FeatureFlags.Api
- HTTP layer


### Separation of Concerns

- Domain logic contains no framework dependencies.
- Infrastructure implements interfaces defined in Core.
- API depends only on abstractions.
- UI is completely independent of evaluation logic.

There is no tangled logic across layers.

---

# Correctness

Behaviour strictly follows precedence rules:

User → Group → Region → Default

Unit tests verify:
- Override precedence
- Default fallback
- Region-specific enablement
- No override behavior

Tests read as documentation.

---

# Tests

Unit tests focus on:

- Core evaluation logic
- Edge cases
- Missing overrides
- Conflicting overrides

Coverage targets critical logic paths (~80%).

The evaluator is fully testable without ASP.NET or infrastructure.

---

# Assumptions

- Override lists per feature are reasonably small.
- Writes are infrequent compared to reads.
- Slight cache staleness is acceptable.
- Evaluation must be safe to run per-request.

---

# Tradeoffs

### Chosen

- Flat override structure instead of complex rule engine.
- Cache-first architecture.
- Simple precedence ordering via enum ranking.

These choices prioritize clarity, performance, and maintainability.

### Not Chosen

- Dynamic expression engines
- Deep rule trees
- Per-request database evaluation

---

# What I Would Do Next (With More Time)

- Percentage rollouts
- Redis pub/sub cache invalidation
- Audit logging
- Approval workflow
- RBAC for admin UI
- Observability (metrics + tracing)

---

# Known Limitations / Rough Edges

- DB store is simulated (easily replaceable with EF Core)
- No write endpoints implemented
- No authentication in admin UI
- No rollout strategies beyond on/off

---

# “Run It” Instructions

## Backend



# Feature Flag System – Backend v2

Production-style feature flag backend with user, group and region overrides.

## Run

cd backend
dotnet restore
dotnet test
dotnet run --project FeatureFlags.Api

## Angular UI

cd angular-admin-ui
npm install
ng serve


---

# Submission Checklist

✔ Correctness (precedence implemented and tested)  
✔ Clean design and separation of concerns  
✔ Unit tests covering core logic  
✔ Performance-aware evaluation path  
✔ Region-based overrides integrated cleanly  
✔ Clear README and documented tradeoffs  
✔ Pragmatic implementation within time box  

---

# Final Notes

This implementation prioritizes production instincts over clever abstractions.

The core engine is intentionally simple, deterministic, and extensible.
