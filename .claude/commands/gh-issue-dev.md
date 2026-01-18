# Issue-Based Development Command

Check the GitHub Issue content using `gh issue view $1` and perform tasks step by step.

## Steps

1. Understand the issue content
2. Checkout main branch and pull to get the latest remote state
3. Create and checkout `issue/$1` branch
4. Identify tasks required to implement the issue
   - Post task list as a comment to GitHub Issue (`gh issue comment $1 --body`)
   - Format tasks as Markdown checklist (`- [ ] task` / `- [x] completed`)
   - Implement in phases
   - Ask user for clarification on unclear points (post questions as comments)
5. Get user approval
   - Wait for approval comment from user on the issue
6. Proceed with implementation based on task list
   - Regularly update progress in issue comments (e.g., when phases complete)
7. After completion, request user to verify functionality
8. Create commits with appropriate granularity
9. Create PR using gh command
   - Include summary of changes in description and `Closes #$1` at the end

## Notes

- Manage all task progress in GitHub Issue comments
- Do not create local files (tasklist.md, etc.)
- Start Claude's comments with `**CLAUDE CODE から送信**`
- If gh command is not installed, prompt user to install and exit
