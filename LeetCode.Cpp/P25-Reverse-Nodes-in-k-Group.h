#pragma once

#include "ListNode.h"

namespace P25
{
	class Solution
	{
	public:
		ListNode* reverseKGroup(ListNode* head, int k)
		{
			if (k == 1 || head == NULL || head->next == NULL) return head;

			ListNode super(0);
			super.next = head;

			ListNode *start = &super, *end = start;
			bool reverse = true;

			while (reverse)
			{
				for (int i = 0; i < k; ++i)
				{
					end = end->next;
					if (end != NULL) continue;
					reverse = false;
					break;
				}

				if (reverse)
				{
					auto curr = start->next;
					start->next = end;
					start = curr->next;
					curr->next = end->next;

					auto nextstart = curr;

					while (true)
					{
						auto next = start->next;
						start->next = curr;
						curr = start;
						if (start == end) break;
						start = next;
					}

					start = end = nextstart;
				}
			}

			return super.next;
		}
	};
}